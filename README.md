
# API REST Prueba Tenica en C# NET CORE 6.0

El consumo de la api creada en este proyecto requiere de una conexión a una base de datos ,sin embargo se puede hacer la prueba de los diferentes servicios creando listas de objetos que simulen el contenido guardado en la base ya que  el proyecto esta esta estructurado por el  modelo MVC.

## POST Autenticacion

```html
https://localhost:44395/Users/Login
```
Genera un token depediendo el usuario y contraseña enviados, que permite utilizar las API's cuya ejecución afectan directamente la base de datos(borrar,actualizar datos).

Body raw (json)
```json

{
    "usuario":"JuanDavidL",
    "password":"Micro1299*"
}
```
## GET ObtenerDescuentos
```html
https://localhost:44395/GetDiscounts
```
Devuelve todos los descuentos registrados en la base de datos.
## GET ObtenerDescuento
```html
https://localhost:44395/GetDescuento?id=2
```
Devuelve el descuentos registrados en la base de datos filtrado por identificador.

| Query Params        |  |
| ------------- | ------------- |
|  id |  2|
## POST InsertarDescuentos
```html
https://localhost:44395/InsertDiscounts
```
Agrega descuentos a la base de datos revisando que no exista el mismo producto, requiere autorización por Token.
## Authorization API Key

| Key           | Authorization |
| ------------- | ------------- |
| Value         |  TokenGenerado|

Body raw (json)

```json
{
  "console": "XBOX",
  "minimalPrice": 100001,
  "maximumPrice": 150000,
  "discount": 7
}
```
## PUT ActualizarDescuento
```html
https://localhost:44395/UpdateDiscounts
```
Actualizar descuento a la base de datos revisando que  el producto exista, requiere autorización por Token.
## Authorization API Key

| Key           | Authorization |
| ------------- | ------------- |
| Value         |  TokenGenerado|

Body raw (json)

```json
{
  "console": "XBOX",
  "minimalPrice": 150001,
  "maximumPrice": 150000,
  "discount": 34
}
```

## DELETE BorrarDescuento
```html
https://localhost:44395/DeleteDiscounts?id=2
```
Borrar descuento a la base de datos revisando  que el producto exista, requiere autorización por Token.
## Authorization API Key

| Key           | Authorization |
| ------------- | ------------- |
| Value         |  TokenGenerado|

| Query Params        |  |
| ------------- | ------------- |
|  id |  2|

## POST InsertarVentas
```html
https://localhost:44395/Sales/InsertSales?QuantityProducts=9&DescriptionSale=PS4
```
Agregar una nueva venta a la base de datos validando que el producto ingresado se encuentre registrado, requiere autorización por Token.
  
## Authorization API Key

| Key           | Authorization |
| ------------- | ------------- |
| Value         |  TokenGenerado|


| Query Params        |  |
| ------------- | ------------- |
|  QuantityProducts |  9|
| DescriptionSale |  PS4|

## GET ObtenerVentas
```html
https://localhost:44395/Sales/GetSales
```
Devuelve todas las ventas registradas en el sistema

## GET ObtenerVenta
```html
https://localhost:44395/Sales/GetSale?id=1
```
Devuelve una venta especificada registrada

## GET SumarVentas
```html
https://localhost:44395/Sales/SumSales?type=T
```
Devuelve el valor total de las ventas registradas filtrando por venta que aplico o no descuento

| Query Params        |  |
| ------------- | ------------- |
|  Type |  T(Todas)|
| Type|  S(Ventas con descuento)|
| Type | N(Ventas sin descuento)|

## GET BorrarVenta

Borra la venta seleccionada,si no encuentra la venta genera mensaje de respuesta,solo se puede acceder por autenticación Token.

```html
https://localhost:44395/DeleteSale?id=1
```
## Authorization API Key

| Key           | Authorization |
| ------------- | ------------- |
| Value         |  TokenGenerado|

| Query Params        |  |
| ------------- | ------------- |
|  id |  1|











