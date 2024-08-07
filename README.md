API para gestion de reservas.

Se deben seguir los siguientes pasos:

1. Correr el siguiente script dentro del SSMS
    use Master
    go
    create database AmvTravel
    go
    use AmvTravel
    go
    create table Tour (
        Id uniqueidentifier primary key not null,
        Nombre varchar(100) not null,
        Destino varchar(100) not null,
        FechaInicio date not null,
        FechaFin date not null,
        Precio decimal(10,2)
    )
    go
    create table Reseva (
        Id uniqueidentifier primary key not null,
        Cliente varchar(100) not null,
        FechaReserva date not null,
        TourId uniqueidentifier not null foreign key references Tour(Id)
    )

2. Levantar la api para su uso inicial.
