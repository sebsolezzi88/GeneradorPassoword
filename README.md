# Generador de contraseñas en C# 🔑

Aplicación de consola en **C#** que permite generar contraseñas utilizando números, letras mayúsculas, letras minúsculas y símbolos.
Incluye la funcionalidad de almacenarlas en una base de datos **SQLite** y la opción de exportarlas a PDF mediante la librería **PDFsharp**.
---
## 📂 Estructura del proyecto

- **Program.cs**: Contiene el menú principal y la interacción con el usuario.
- **Arreglos.cs**: Dentro se encuentra la Clase RandomData que maneja la creación de la contraseña. Con las funciones estáticas: `GetRamdonMayusLetters`, `GetRamdonMinusLetters`, `GetRamdonSymbols`,`GetRamdonNumber` y `GeneratePassword`

---

## 🚀 Uso

1. Clonar el repositorio:

```
git clone https://github.com/sebsolezzi88/GeneradorPassoword
```

2. Abrir el proyecto en Visual Studio o Visual Studio Code.

3. Ejecutar el proyecto. Aparecerá un menú en consola:
```
--- Generador de contraseñas C# ---
Ingrese 
| 1-Crear contraseña 
| 2-Listar contraseñas
| 3-Eliminar contraseña
| 4-Salir
Opción: 
```
4. Cuando seleccione opción 1, deberá ingresar los datos que le pida el programá y obtendrá su contraseña. Si desea guardarla en la base de datos debe responder con la letra "S". Se le solicitará un nombre de no más de 20 caracteres para poder guardarla.
```
Ahora deberá ingresar la cantidad de letras, números y simbolos que tendrá su contraseña
Ingrese la cantidad de simbolos. Mínimo 1, Máximo 6: 2
Ingrese la cantidad de letras mayusculas. Mínimo 1, Máximo 6: 4
Ingrese la cantidad de letras minusculas. Mínimo 1, Máximo 6: 6
Ingrese la cantidad de números. Mínimo 1, Máximo 6: 3
La contraseña generada: 4drAz&XQhpF1l4/
¿Desea guardar la contraseña generada? S/N: S
Ingrese un nombre para guardar la contraseña: sitio.com
Password guardado correctamente.
```
5. Si elige la opción 3 se le solicitará el ID de la contraseña que desea eliminar
```
Ingrese el Id de la contraseña a borrar: 
```
6. Si desea generar un archivo **PDF** con todas las contraseña primero debe elegir la opción 2.

```
Ingrese -> 
 | 1-Crear contraseña 
 | 2-Listar contraseñas 
 | 3-Eliminar contraseña 
 | 4-Salir
Opción: 2
ID: 1 - Nombre: youtube - Contraseña: Dh/7At&H+m05
ID: 2 - Nombre: facebook - Contraseña: ;b1]8B`#11F2i1B
ID: 4 - Nombre: google - Contraseña: Oh40_vn8xP2:T
¿Desea generar un PDF con las contraseñas? S/N: 
```
7. Ingrese la legra "S" y se generará el archivo **Passwords.pdf** 
----
## Requisitos
- [.NET 6 o superior](https://dotnet.microsoft.com/es-es/download)
- [Sqlite](https://www.nuget.org/packages/Microsoft.Data.Sqlite/10.0.0-preview.7.25380.108)
- [PDFsharp](https://www.nuget.org/packages/PDFsharp#versions-body-tab)





