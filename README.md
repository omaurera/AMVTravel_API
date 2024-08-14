<h1 align="center"> API para gestion de reservas. </h1>
<br/>
<p align="left">Se deben seguir los siguientes pasos:</p>

<p align="left">1. Correr el siguiente script dentro del SSMS</p>
   
    use Master
    go
    create database AmvTravel
    go
    use AmvTravel
    go
    create table Usuario (
        Id uniqueidentifier not null primary key,
        Nombre varchar(100) not null,
        Apellido varchar(100) not null,
        NombreUsuario varchar(
        Contrasena varchar(max) not null
    )
    go
    insert into Usuario
    values (newid(), 'Omar', 'Maurera', 'YW12dHJhdmVsMjAyNA==')
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
    create table Reserva (
        Id uniqueidentifier primary key not null,
        Cliente varchar(100) not null,
        FechaReserva date not null,
        TourId uniqueidentifier not null foreign key references Tour(Id)
    )

<p align="left">2. Levantar la api para su uso inicial.</p>
