# 🏦 Microservicios — Gestión de Clientes y Pagos

> Solución empresarial desarrollada en **.NET 8** bajo arquitectura de **Microservicios + Clean Architecture**

---

## 📋 Tabla de Contenidos

- [Descripción](#-descripción)
- [Arquitectura](#-arquitectura)
- [Tecnologías](#-tecnologías)
- [Base de Datos](#-base-de-datos)
- [Ejecución](#-ejecución)
- [Endpoints y Swagger](#-endpoints-y-swagger)
- [Casos de Prueba](#-casos-de-prueba)
- [Validaciones](#-validaciones)

---

## 📖 Descripción

Sistema de microservicios que permite:

- ✅ Registrar y consultar **clientes**
- ✅ Gestionar y consultar **pagos**
- ✅ Consultar **historial de pagos** por cliente

### Historias de Usuario cubiertas

| ID | Descripción |
|----|-------------|
| HU-001 | Registro de clientes |
| HU-002 | Consulta de clientes |
| HU-004 | Registro de pagos |
| HU-005 | Consulta de historial de pagos |

---

## 🏗️ Arquitectura

El sistema está compuesto por **dos microservicios independientes**, cada uno organizado en capas siguiendo **Clean Architecture**:

```
📦 Solution
├── 🔹 ClientesService
│   ├── Domain
│   ├── Application
│   ├── Infrastructure
│   └── Api  →  :5001
│
└── 🔸 PagosService
    ├── Domain
    ├── Application
    ├── Infrastructure
    └── Api  →  :5002
```

### Flujo del sistema

```
Cliente
  │
  ├──▶ [Registro]   ──▶ Validación ──▶ BD (Clientes)
  │
  ├──▶ [Pago]       ──▶ Validación ──▶ BD (Pagos)
  │                        │
  │                   Verifica cliente existente
  │
  └──▶ [Historial]  ──▶ BD ──▶ Ordenado por fecha ↓
```

---

## 🛠️ Tecnologías

| Tecnología | Uso |
|------------|-----|
| .NET 8 | Framework principal |
| Entity Framework Core | ORM / acceso a datos |
| MySQL | Motor de base de datos |
| Swagger / OpenAPI | Documentación de endpoints |
| Clean Architecture | Patrón de diseño |
| Microservicios | Arquitectura del sistema |

---

## 🗄️ Base de Datos

> Motor: **MySQL** · Modelo: **Tercera Forma Normal (3FN)**

```sql
CREATE DATABASE microservicios;
USE microservicios;

-- CLIENTES
CREATE TABLE Clientes (
    Id             INT AUTO_INCREMENT PRIMARY KEY,
    Documento      VARCHAR(50)  NOT NULL,
    TipoDocumento  VARCHAR(10)  NOT NULL,
    Nombres        VARCHAR(100) NOT NULL,
    Apellidos      VARCHAR(100) NOT NULL,
    Email          VARCHAR(150) NOT NULL,
    Celular        VARCHAR(20),
    NumeroCuenta   VARCHAR(50)  NOT NULL,
    TipoCuenta     VARCHAR(20)  NOT NULL,
    Estado         BOOLEAN DEFAULT TRUE
);

-- PAGOS
CREATE TABLE Pagos (
    Id          INT AUTO_INCREMENT PRIMARY KEY,
    ClienteId   INT            NOT NULL,
    TipoPago    VARCHAR(10)    NOT NULL,
    Cuenta      VARCHAR(50)    NOT NULL,
    Valor       DECIMAL(10,2)  NOT NULL,
    Descripcion TEXT,
    Fecha       DATETIME DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);
```

---

## 🚀 Ejecución

> ⚠️ **IMPORTANTE:** Ambos proyectos API deben ejecutarse simultáneamente.

### Visual Studio 2022+

1. Click derecho sobre la **Solución**
2. Seleccionar **"Set Startup Projects..."**
3. Elegir **"Multiple startup projects"**
4. Configurar:

| Proyecto | Acción |
|----------|--------|
| `Clientes.Api` | **Start** |
| `Pagos.Api` | **Start** |

5. Presionar **▶ Run**

---

## 🧪 Casos de Prueba

### 👤 Clientes — `POST /api/clientes`

#### ✅ Registro exitoso

```json
{
  "documento": "12345",
  "tipoDocumento": "CC",
  "nombres": "Duvan",
  "apellidos": "Alzate",
  "email": "user@example.com",
  "celular": "304632146",
  "numeroCuenta": "123",
  "tipoCuenta": "Ahorros"
}
```
> ✔ Cliente registrado · Estado activo por defecto

---

#### ❌ TipoDocumento inválido

```json
{
  "tipoDocumento": "AAAA"
  // ...resto del body
}
```
> ❌ `Tipo de documento inválido` — controlado con enum

#### ❌ Email inválido

```json
{
  "email": "correo_invalido"
  // ...resto del body
}
```
> ❌ `Formato de correo inválido`

#### ❌ Celular inválido

```json
{
  "celular": "ABC123"
  // ...resto del body
}
```
> ❌ `Solo números permitidos`

---

### 💳 Pagos — `POST /api/pagos`

#### ✅ Pago exitoso

```json
{
  "clienteId": 1,
  "tipoPago": "Credito",
  "cuenta": "123",
  "valor": 150000.50,
  "descripcion": "Pago inicial"
}
```
> ✔ Pago registrado correctamente

---

#### ❌ TipoPago inválido

```json
{
  "tipoPago": "XXXX"
  // ...resto del body
}
```
> ❌ `Tipo de pago inválido`

#### ❌ Valor inválido

```json
{
  "valor": 0
  // ...resto del body
}
```
> ❌ `Valor debe ser mayor a 0`

#### ❌ Cliente inexistente

```json
{
  "clienteId": 999
  // ...resto del body
}
```
> ❌ `Cliente no existe`

---

### 📊 Historial de Pagos

```
GET /api/pagos/{clienteId}
```

> ✔ Devuelve lista de pagos ordenados por **fecha descendente**

---

## ✅ Validaciones Implementadas

### Clientes

| Campo | Regla |
|-------|-------|
| Documento | Obligatorio |
| TipoDocumento | Enum: `CC`, `CE`, `TI`, etc. |
| Nombres | Obligatorio |
| Apellidos | Obligatorio |
| Email | Formato válido |
| Celular | Solo numérico |
| NumeroCuenta | Obligatorio |
| TipoCuenta | Obligatorio |
| Estado | `true` por defecto |

### Pagos

| Campo | Regla |
|-------|-------|
| TipoPago | Enum: `Credito` / `Debito` |
| Cuenta | Obligatoria |
| Valor | Obligatorio · Decimal · Mayor a `0` |
| Descripcion | Opcional |
| ClienteId | Debe existir en BD |
| Fecha | Auto-generada, orden descendente |

---

<div align="center">

Desarrollado con ❤️ en **.NET 8** · Clean Architecture · Microservicios

</div>
