# TODO App SQLite en C# 🔑

Una pequeña aplicación de consola en C# que permite generar contraseñas usando **números**, **letras mayúsculas**, **letras minúsculas** y **simbolos**

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
Ingrese 1-Crear contraseña | 2-Salir
Opción: 
```
4. Cuando seleccione opción 1, deberá ingresar los datos que le pida el programá y obtendrá su contraseña.
```
Ahora deberá ingresar la cantidad de letras, números y simbolos que tendrá su contraseña
Ingrese la cantidad de simbolos. Mínimo 1, Máximo 6: 4
Ingrese la cantidad de letras mayusculas. Mínimo 1, Máximo 6: 5
Ingrese la cantidad de letras minusculas. Mínimo 1, Máximo 6: 6
Ingrese la cantidad de números. Mínimo 1, Máximo 6: 6
La contraseña generada: vjr}g620%aVEcMH.707B;
```
---
## 🚧 Mejoras
El proyecto se actualizará para almacenar las contraseñas en un archivo .txt o en una base de datos SQLite.

----
## Requisitos
- [.NET 6 o superior](https://dotnet.microsoft.com/es-es/download)


