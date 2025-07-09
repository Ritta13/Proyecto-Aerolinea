# ✈️ Sistema de Gestión de Reservas de Vuelos

---

## 📌 Descripción

Este proyecto permite a una aerolínea gestionar reservas de vuelos y ventas de pasajes, implementando funcionalidades diferenciadas según el rol del usuario.

---

## 👤 Usuario Anónimo
- **Registrarse como cliente ocasional:** Completar datos solicitados. La contraseña debe ser alfanumérica y tener un mínimo de 8 caracteres. Al registrarse, queda logueado automáticamente.
- **Login:** Acceso mediante email y contraseña. Si son correctos, el usuario ingresa a las funcionalidades correspondientes a su rol.

---

## 🧳 Usuario Cliente
- **Ver todos los vuelos:** Listado de vuelos disponibles con opción de compra.
- **Buscar vuelos por ruta:** Filtrar vuelos ingresando los códigos de aeropuerto de salida y/o llegada.
- **Comprar pasaje:** Seleccionar fecha (validada según la frecuencia del vuelo) y elegir equipaje.
- **Ver pasajes comprados:** Listado de pasajes ordenados por precio descendente.
- **Ver perfil:** Visualización de datos personales; los clientes premium ven también sus puntos acumulados.
- **Logout:** Cierre de sesión.

---

## 🛠️ Usuario Administrador
- **Ver todos los pasajes:** Listado completo de pasajes emitidos ordenados por fecha.
- **Ver/editar todos los clientes:** Listado de clientes ordenados por documento.
  - Clientes premium: visualizar y editar puntos.
  - Clientes ocasionales: ver si es elegible y editarlo.
- **Logout:** Cierre de sesión.

---

## 🚀 Tecnologías y herramientas
- ASP.NET 8.0 / MVC
- C#
- Visual Studio 2022
- Base de datos: **dlocalstrange**

---

## 🌐 Ver online
👉 [https://airline-fkbjf5befdddh4f9.eastus-01.azurewebsites.net/](https://airline-fkbjf5befdddh4f9.eastus-01.azurewebsites.net/)

---

