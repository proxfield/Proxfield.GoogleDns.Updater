# Proxfield.GoogleDns.Updater
Service worker that updates the Google DDNS registry from time to time, runs as a Docker standalone service.

## Google DDNS Service
Google provides to anyone who has a domain within the [domains.google](domains.google) to create subdomains and associate them to any publuc IP address via DDNS, the main differente to usual DNS is that we can easily update the IP in which the subdomain points to. That's a great thing for people and companies who don't yet have a "static" public IP Address.

### Creating an subdomain
Go to [Google Registrar](https://domains.google.com/registrar/) and find the domain you want to create the subdomain, then select on the left menu the DNS item as shown:
![image](https://github.com/proxfield/Proxfield.GoogleDns.Updater/assets/7343019/ce0f3afd-7d6e-4298-a574-4b2ccf5ac018)

On the bottom of the page click on "Show Advanced Settings":
![image](https://github.com/proxfield/Proxfield.GoogleDns.Updater/assets/7343019/971486f2-b23f-487e-b04f-26590d2933dd)

Then a Dynamic DNS option will be available for you, click on "Manage Dynamic DNS" and create your own:
![image](https://github.com/proxfield/Proxfield.GoogleDns.Updater/assets/7343019/9a3b27d5-312b-470a-a459-1c35dedc701f)

Please take a note of the:
* Endpoint/subdomain you've selected (e.g.: lks.proxfield.com);
* Username (available at the button "View credentials");
* Password (available at the button "View credentials").

## Running via Dockerfile

There is a file named `secrets.example.env`, copy it to `secrets.env`:
```bash
    cp secrets.example.env secrets.env
```
Edit the `secrets.env` file with the following data grabbed from the Google Domains:

```ini
HOST_NAME=
USER=
PASSWORD=
INTERVAL=300
```

* HOST_NAME: subdomain in which the IP will be bind to;
* USER: username provided when clicking on "View Credentials"
* PASSWORD: password provided when clicking on "View Credentials"
* INTERVAL: given in seconds, stabilishes from what amount of time the worker should update the Google Registry (please do not select a value that is necessary to your application, so not to be banned or something);

Then run the application either using the `up.sh` script or creating the image yourself by running the following commands:

```bash
docker build -t googleddnsupdater .
docker tag googleddnsupdater:latest googleddnsupdater:staging
docker compose --env-file ./secrets.env  up -d
```

### Checking the logs
This worker has logging implemented, so we can track what is happening in real time (ish), feel free to use it.
```bash
docker logs -f googleddnsupdater
```

## Running via Docker Composer
Comming soon

## Under the hood

Using this service to update the Google registry couldn't be applicable to your scenario, this was developed to run on a docker environment we already have; if you need to create your own updater for some reason, here's how it works on a nutshell:

The service sends a request to the following URL: `https://domains.google.com/nic/update?hostname={hostName}`, in which the **hostname** is the subdomain you've created. 

The credentials are passed either by the URL itself, as in `https://username:password@domains.google.com/nic/update?hostname=subdomain.yourdomain.com&myip=1.2.3.4`, which is not that safe. Also note that it is not necessary to pass your IP address on the **myip** query parameter, it is completely optional, since when not provided it will assume your own IP.
