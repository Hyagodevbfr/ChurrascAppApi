
# 🍖 Churrasc App

A collaborative **barbecue** organization system, with the option to add an optional extra activity (soccer, pool, pagode, etc.).

> This project is being developed with a focus on personal technical challenges, but with a professional structure for real-world testing and continuous development. The entire development process is being documented in this repository.

---

## ✅ Objective

Create a robust and organized application that allows anyone to:
- Create a barbecue with or without a complementary activity
- Share an invitation link
- Control participants, contributions, and items
- Define whether contributions will be by value, by items, or both
- Approve or deny participation requests

---
## 🧱 Core Entities

| Entity         | Description |
|----------------|-------------|
| **User**       | Represents a registered user on the platform. Can create barbecue events and/or participate in them. |
| **Event**      | Represents a barbecue event created by a user. Includes date, location, contribution rules, items defined by the organizer, and an optional extra activity. |
| **JoinRequest** | A request made by a user to participate in a barbecue. The organizer must approve it before the user can proceed. |
| **Participant** | A user who was authorized and has confirmed their participation in the event, including their contribution. |

---

### 📌 `Event` (Barbecue)
- `id`
- `name`, `description`
- `date`, `time`, `location`
- `createdAt`
- `organizer` (reference to the user who created the event)
    - `id`
    - `name`
    - `number`
- `contributionType`: value, item, or hybrid
- - `extraActivity` (optional):
  - `name`: e.g., Soccer, Pool
  - `description`
  - `individualCost`: amount each participant pays (if applicable)
- `requiredItems`: list of objects:
  - `name`: e.g., Meat, Ice
  - `requiredQuantity`
  - `assignedQuantity`
  - `estimatedCost`
  - `assignedUserId` (optional)

- `totalCost`
- `inviteCode`: used for sharing the event
- `limited guests?`
- `numberOfGuests`
- `guests`
   - `id`
   - `name`
   - `number`
- `confirmed`
   - `id`
   - `name`
   - `number`
   - `contribuition`
     
      -`confirmedPayment`
     
      - `item`
  - `isInExtra`

---

### 📌 `User`
- `id`
- `firstName`
- `lastName`
- `email`
- `cpf` (Brazilian ID)
- `phone`
- `password`

---

### 📌 `JoinRequest` (Participation Request)
- `user`
  - `id`
  - `name` 
- `eventId`
- `status`: `pending`, `authorized`, `rejected`, `cancelled`
- `requestedAt`

> This is a basic participation request. The organizer must **authorize** the user before they can proceed to confirm participation and define their contribution. Until authorized, the user only sees public event information.

---

### 📌 `Participant`
- `id`
- `user`
  - `id`
  - `name` 
- `eventId`
- `assignedItem` or `contributedAmount`
- `participatingInExtraActivity`: true/false
- `status`: confirmed, absent, etc.
- `confirmedAt`

> The `Participant` record is created only after the organizer authorizes the user, and the user completes their contribution details and confirms attendance.

---
## 🎯 Defined Features

This section lists all the key features currently planned or implemented in the platform.

### 🔐 Authentication
- User registration and login
- View your created and joined events

### 📅 Event Management
- Create barbecue events
- Set location, date, time and description
- Define contribution type (items, money or hybrid)
- Enable optional extra activity (e.g., soccer)
- Generate and share invite link

### 🤝 Participation Flow
- Public users can access shared events with limited view
- Request to join an event
- Organizer can approve or reject requests
- Authorized users can confirm attendance and define contributions

### 🧾 Event Control
- Organizer can view confirmed participants
- Track item distribution and missing items
- Track extra activity participation

### 📸 Post-Event
- Participants can upload event photos (limited per user)
---
## 🧱 Architecture

The project follows a layered architecture using **MongoDB** as the database.

### 🔹 Layers

- **Domain**: Business rules and entities (e.g., Event, User, JoinRequest, Participant)  
- **Application**: Services and use cases (e.g., creating events, managing participation)  
- **Infrastructure**: MongoDB repositories and external integrations  
- **API**: HTTP endpoints, input/output mapping  
- **Testing**: Separate test projects for unit, integration, and end-to-end tests
### 🔹 Database (MongoDB)

Collections:
- `users`
- `events`
- `joinRequests`
- `participants`

> Items and extra activity are embedded directly in the event document.
---
# Project Folder Structure

/src  
├── Domain  
│   ├── Entities           # Domain entities (Event, User, Participant, JoinRequest)  
│   ├── ValueObjects       # Value Objects  
│   ├── Repositories       # Repository interfaces (e.g., IEventRepository)  
│   ├── Services           # Pure domain services (business logic, validations)  
│   ├── Events             # Domain events  
│   └── Specifications     # Reusable business rules and specifications  
│  
├── Application  
│   ├── DTOs               # Data Transfer Objects  
│   ├── Services           # Application services (use cases)  
│   ├── Interfaces         # Service interfaces and contracts  
│   ├── Commands           # Commands for actions (optional, CQRS)  
│   └── Queries            # Queries (optional, CQRS)  
│  
├── Infrastructure  
│   ├── Persistence        # Repository implementations using MongoDB  
│   ├── ExternalServices   # External integrations (email, messaging, etc.)  
│   └── Configurations     # Database and service configurations  
│  
├── API  
│   ├── Controllers        # HTTP API controllers and endpoints  
│   ├── Models             # API models (ViewModels, InputModels)  
│   └── Filters            # API filters and middleware  
│  
└── tests  
    ├── Domain.Tests       # Unit tests for domain layer  
    ├── Application.Tests  # Tests for application layer  
    ├── Infrastructure.Tests # Integration tests (e.g., MongoDB)  
    └── API.Tests          # API integration and end-to-end tests  

---

# Responsibilities by Layer

| Layer           | Responsibility                                                      |
|-----------------|--------------------------------------------------------------------|
| **Domain**      | Business rules, entities, pure domain services, interfaces, domain events, value objects |
| **Application** | Use cases, orchestration of domain and infrastructure, DTOs, application validation |
| **Infrastructure** | Data access implementations (MongoDB), external services, configurations |
| **API**         | Controllers, endpoints, input/output models, middleware, authentication |
| **Tests**       | Unit, integration, and end-to-end tests separated by layer         |

---

## 🚧 Current Status

✅ Main idea defined  
✅ Target audience identified  
✅ Planned features  
✅ Mapped entities  
✅ Documented participation flow  
✅ Defined business rules  
✅ Chosen layered architecture  
✅ Selected database (MongoDB)  
✅ Modeled document structure  
✅ README started with consistent documentation

---

## License

[MIT](https://choosealicense.com/licenses/mit/)

