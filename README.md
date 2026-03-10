# TourHub.Microservices 🌍✈️

A sample microservices architecture built with ASP.NET Core Minimal APIs and **YARP (Yet Another Reverse Proxy)**. This project demonstrates how to set up an API Gateway to route traffic across multiple independent domain services within a Tour Management system.

## 🏗️ Project Structure

The solution consists of a centralized YARP API Gateway and four backend microservices.

```text
TourHub.Microservices/
│
├── TourHub.ApiGateway/       # (Port 5000) The YARP Reverse Proxy
├── TourHub.CatalogService/   # (Port 5011) Manages tour packages & destinations
├── TourHub.BookingService/   # (Port 5012) Handles customer reservations
├── TourHub.CustomerService/  # (Port 5013) Manages user profiles & loyalty points
└── TourHub.PaymentService/   # (Port 5014) Processes mock transactions

```

## ⚙️ Architecture Overview

All client requests (from a frontend app, mobile app, or Postman) are sent to the **ApiGateway** on port `5000`. YARP inspects the URL path and seamlessly routes the request to the appropriate internal microservice.

| Service | Internal Port | Gateway Route | Purpose |
| --- | --- | --- | --- |
| **ApiGateway** | `5000` | `/` | Single entry point; handles routing via `appsettings.json`. |
| **CatalogService** | `5011` | `/api/tours/*` | Returns available tours and package details. |
| **BookingService** | `5012` | `/api/bookings/*` | Manages creating and viewing tour bookings. |
| **CustomerService** | `5013` | `/api/customers/*` | Serves customer profile data. |
| **PaymentService** | `5014` | `/api/payments/*` | Handles transaction status and history. |

## 🚀 How to Run Locally

To see the Gateway in action, you need to run all five projects simultaneously.

1. Open your terminal at the root of the solution.
2. Open 5 separate terminal tabs/windows.
3. Run the following commands, one in each terminal:

```bash
dotnet run --project TourHub.CatalogService
dotnet run --project TourHub.BookingService
dotnet run --project TourHub.CustomerService
dotnet run --project TourHub.PaymentService
dotnet run --project TourHub.ApiGateway

```

## 🧪 Testing the Gateway

Once all services are running, you can test the routing by making requests exclusively to the Gateway (`localhost:5000`).

### 1. Catalog (Tours)

* **GET All Tours:** `http://localhost:5000/api/tours`
* **GET Single Tour:** `http://localhost:5000/api/tours/1`

### 2. Bookings

* **GET All Bookings:** `http://localhost:5000/api/bookings`
* **POST New Booking:** `http://localhost:5000/api/bookings`

### 3. Customers

* **GET All Customers:** `http://localhost:5000/api/customers`
* **GET Single Customer:** `http://localhost:5000/api/customers/2`

### 4. Payments

* **GET All Payments:** `http://localhost:5000/api/payments`
* **GET Single Payment:** `http://localhost:5000/api/payments/TXN-1001`

## 🛠️ Built With

* [ASP.NET Core 10 Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis)
* [YARP (Yet Another Reverse Proxy)](https://microsoft.github.io/reverse-proxy/)

