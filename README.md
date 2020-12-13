<h1 align="center">Welcome to UrlShorter 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0-blue.svg?cacheSeconds=2592000" />
  <a href="https://github.com/Gaojianli/UrlShorter/blob/master/LICENSE" target="_blank">
    <img alt="License: MIT" src="https://img.shields.io/badge/License-MIT-yellow.svg" />
  </a>
  <a href="https://app.fossa.com/projects/git%2Bgithub.com%2FGaojianli%2FUrlShorter?ref=badge_shield" target="_blank">
    <img alt="FOSSA: Scan" src="https://app.fossa.com/api/projects/git%2Bgithub.com%2FGaojianli%2FUrlShorter.svg?type=shield">
  </a>
</p>

> ShortURL is a open source URL shortening service (a.k.a URL redirection) allowing anyone to take any existing URL and shorten it.

### ✨ Demo: https://short.u2b.eu
### Webui: https://github.com/Gaojianli/UrlShorter-web
## Config

|Name|Type|Details|
|:-|:-|:-|
|SqlConnection|string|The [connection string](https://www.connectionstrings.com/) of the database|
|origin|string|The origin of the web ui, usually is just the URL of the web. If you set this uncorrectly, you may meet CORS error.|
|homePage|string|The URL of the web, if one short url is missing, the user will be redirected here.|
|prefix|string|The prefix of each short url.|

Here're the config running on https://short.u2b.eu:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "SqlConnection": "server=localhost;port=3306;database=shortUrl;uid=shorturl;pwd=<pwd>;CharSet=utf8"
  },
  "SiteSettings": {
    "origin": "https://short.u2b.eu",
    "homePage": "https://short.u2b.eu",
    "prefix": "https://u2b.eu"
  },
  "Kestrel": {
    "EndPoints": {
      "Http": {
        "Url": "http://0.0.0.0:5000"
      }
    }
  }
}
```

## Install
### Docker(Recommended)
1. Import the `init.sql` into your Mysql/Mariadb
1. Run the container
```bash
docker run -d -e ConnectionStrings__SqlConnection="server=<ip to the db>;port=<db port>;database=shortUrl;uid=shorturl;pwd=<pwd>;CharSet=utf8" \
-e SiteSettings__origin="https://short.u2b.eu" \
-e SiteSettings__homePage="https://short.u2b.eu" \
-e SiteSettings__prefix="https://u2b.eu" \
-p 5000:5000 \
--name url_shorter \
--restart=always \
url_shorter
```


### Manually
1. Import the `init.sql` into your Mysql/Mariadb
1. Edit your database config in `appsettings.json`, then run:

```sh
dotnet build
```

## Usage

```sh
dotnet run
```

## Author

👤 **Gaojianli**

* Website: https://blog.gaojianli.me
* Github: [@Gaojianli](https://github.com/Gaojianli)

## Show your support

Give a ⭐️ if this project helped you!

## 📝 License

Copyright © 2020 [Gaojianli](https://github.com/Gaojianli).<br />
This project is [MIT](https://github.com/Gaojianli/UrlShorter/blob/master/LICENSE) licensed.
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FGaojianli%2FUrlShorter.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FGaojianli%2FUrlShorter?ref=badge_large)


***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_