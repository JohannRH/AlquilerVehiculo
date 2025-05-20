create database AlquilerDB
go
use AlquilerDB
go

-- Tabla de sedes
CREATE TABLE Sedes (
    id_sede int PRIMARY KEY,
    nombre VARCHAR(100),
    direccion VARCHAR(200),
    ciudad VARCHAR(100)
);
go
-- Tabla de tipos de vehículos
CREATE TABLE TiposVehiculos (
    id_tipo int PRIMARY KEY,
    nombre VARCHAR(50),
    descripcion TEXT
);
go
-- Tabla de vehículos
CREATE TABLE Vehiculos (
    id_vehiculo int PRIMARY KEY,
    placa VARCHAR(20) UNIQUE,
    marca VARCHAR(50),
    modelo VARCHAR(50),
    año INT,
    id_tipo INT,
    id_sede INT,
    estado VARCHAR(20) CHECK (estado IN ('disponible', 'alquilado', 'mantenimiento', 'vendido')),
    fecha_compra DATE,
    precio_compra DECIMAL(10,2),

	FOREIGN KEY (id_tipo) REFERENCES TiposVehiculos(id_tipo),
	FOREIGN KEY (id_sede) REFERENCES Sedes(id_sede)
);

-- Tabla de clientes
CREATE TABLE Clientes (
    id_cliente int PRIMARY KEY,
    nombre VARCHAR(100),
    nacionalidad VARCHAR(50),
    identificacion VARCHAR(50),
    tipo_cliente VARCHAR(20) CHECK (tipo_cliente IN ('nacional', 'extranjero')),
    telefono VARCHAR(20),
    email VARCHAR(100)
);

-- Tabla de reservas
CREATE TABLE Reservas (
    id_reserva int PRIMARY KEY,
    id_cliente INT,
    id_vehiculo INT,
    fecha_reserva DATE,
    fecha_inicio DATE,
    fecha_fin DATE,
    estado VARCHAR(20) CHECK (estado IN ('pendiente', 'confirmada', 'cancelada')),

	FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente),
	FOREIGN KEY (id_vehiculo) REFERENCES Vehiculos(id_vehiculo)
);

-- Tabla de rentas
CREATE TABLE Rentas (
    id_renta int PRIMARY KEY,
    id_reserva INT,
    fecha_inicio DATE,
    fecha_fin_estimada DATE,
    costo_total_est DECIMAL(10,2),

	FOREIGN KEY (id_reserva) REFERENCES Reservas(id_reserva)
);

-- Tabla de devoluciones
CREATE TABLE Devoluciones (
    id_devolucion int PRIMARY KEY,
    id_renta INT,
    fecha_devolucion DATE,
    kilometraje_final INT,
    observaciones TEXT,
    costo_final DECIMAL(10,2),

	FOREIGN KEY (id_renta) REFERENCES Rentas(id_renta)
);

-- Tabla de ventas (vehículos vendidos al final de su vida útil)
CREATE TABLE Ventas (
    id_venta int PRIMARY KEY,
    id_vehiculo INT REFERENCES Vehiculos(id_vehiculo),
    fecha_venta DATE,
    precio_venta DECIMAL(10,2),
    comprador_nombre VARCHAR(100),

	FOREIGN KEY (id_vehiculo) REFERENCES Vehiculos(id_vehiculo)
);


select * from Sedes
select * from Vehiculos
select * from TiposVehiculos
select * from Clientes
select * from Reservas
select * from Rentas
select * from Devoluciones
