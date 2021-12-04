# Back-End of the project "Planium"
[![Build Status](https://dev.azure.com/known-project/back-end/_apis/build/status/back-end-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/known-project/back-end/_build/latest?definitionId=2&branchName=master)

## What we've done

- Implemented the back-end REST API of the project using ASP.NET Core framework.
- Used PostgreSQL and Entity Framework for data persistence.
- Leveraged the MVC pattern for code structuring.
- Collaborated in a team of 5 under Scrum methodology.

## Prerequisites

### ASP.NET Core
* Installation on [Microsoft website](https://dotnet.microsoft.com/download/linux-package-manager/fedora28/sdk-current)

### Postgresql
* Installation
```bash
$ sudo dnf install postgresql-server postgresql-contrib
$ sudo systemctl enable postgresql
$ sudo systemctl start postgresql
$ sudo postgresql-setup --initdb --unit postgresql
```
* Change password
```bash
$ sudo su
$ su - postgres
$ psql
postgres=# \password postgres
```
* Change "ident" to "md5" in the config file
```bash
$ sudo vim /var/lib/pgsql/data/pg_hba.conf
# restart service
$ sudo systemctl restart postgresql.service
```
* More info on [Fedora website](https://fedoraproject.org/wiki/PostgreSQL)

### EF Core
```bash
$ dotnet ef database update
```
