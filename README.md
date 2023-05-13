# General info
This project is example ASP.NET Web API application using basic technologies but without a database. \
This using pattern CQRS.

---

# Technologies
Project is created with:

* Swashbuckle.AspNetCore: 6.5.0
* Newtonsoft.Json: 13.0.3
* AutoMapper: 12.0.1
* MediatR: 12.0.1

***

# Setup

## Native

---

Where **8080** is free port number your computer.

```
$ cd ./Sample.WebAPI
$ dotnet run --urls=http://localhost:8080
```

Then go to: http://localhost:8080/swagger

## Docker

---

Where **example** is name image. \
Where **testapp** is name container. \
Where **8080** is free port number your computer.

```
$ docker build -t example .
$ docker run -d -p 8080:80 --name testapp example
```

Then go to: http://localhost:8080/swagger
