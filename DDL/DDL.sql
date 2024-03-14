create table cliente(
	id_cliente int identity(1,1) primary key, 
	nombre varchar(50), 
	apellido varchar(50), 
	direccion varchar(50),
	telefono varchar(10), 
	cedula varchar(10), 
	eliminado bit
);

create table estado_pedido(
	id_estado_pedido int primary key, 
	nombre varchar(50)
);

create table puesto(
	id_puesto int primary key, 
	nombre varchar(50)
);

create table empleado(
	id_empleado int identity(1,1) primary key, 
	nombre varchar(50), 
	apellido varchar(50), 
	telefono varchar(10), 
	cedula varchar(10), 
	eliminado bit, 
	id_puesto int, 
	foreign key (id_puesto) references puesto (id_puesto)
);

create table pedido(
	id_pedido int identity(1,1) primary key, 
	id_cliente int, id_empleado int, id_estado_pedido int, 
	total decimal(10,2)
);

create table producto(
	id_producto int identity(1,1) primary key, 
	codigo_producto int, 
	descripcion varchar(255), 
	nombre varchar(50), 
	precio decimal(10,2), 
	eliminado bit

);

create table detalle_pedido(
	id_detalle_pedido int identity(1,1) primary key, 
	id_pedido int, 
	id_producto int, 
	cantidad int, 
	subtotal decimal(10,2), 
	foreign key (id_pedido) references pedido (id_pedido), 
	foreign key (id_producto) references producto(id_producto)
);


create table usuario(
	id_usuario int identity(1,1) primary key, 
	usuario varchar(50), 
	correo varchar(50),
	clave varchar(50), 
);
