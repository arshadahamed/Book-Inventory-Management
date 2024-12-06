
# Book Inventory Management System (BIM)

## **Project Description**
The **Book Inventory Management System (BIM)** is a comprehensive solution for managing a book inventory efficiently. It allows Admin users to perform CRUD operations and provides Normal Users with an intuitive and responsive interface to browse and search books. The system adheres to modern development principles, including **SOLID, OOP, Clean Architecture,** and **Separation of Concerns.**

---

## **Features**
### **Admin Role**
- Full access to manage books (create, read, update, delete).
- Search and filter books by title, author, genre, or ISBN.

### **Normal User Role**
- Read-only access to view and search books in the inventory.

### **Authentication**
- Role-based authentication with JWT (JSON Web Tokens).
- Secure login and signup functionality.

### **Responsive UI**
- Works seamlessly across devices (desktop and mobile).

---

## **Technology Stack**
### **Frontend**
- **Framework**: Vue.js with Vite
- **Styling**: Tailwind CSS
- **Data Handling**: Axios for API requests with caching
- **Optimization**: Code-splitting and lazy loading

### **Backend**
- **Framework**: ASP.NET Core Web API
- **Database**: Microsoft SQL Server with Entity Framework Core
- **Authentication**: JWT with ASP.NET Identity
- **Design Patterns**: Repository, CQRS, and Mediator

---

## **Project Structure**

### **Backend Folder Structure**
```
BIM.API
├── Controllers
│   ├── BooksController
│   └── AccountController
├── Middlewares
│   ├── ErrorHandlingMiddleware
│   └── RequestTimeLoggingMiddleware

BIM.Application
├── Commands
│   ├── CreateBookCommand
│   ├── UpdateBookCommand
│   ├── DeleteBookCommand
├── Queries
│   ├── GetAllBooksQuery
│   └── SearchBooksQuery

BIM.Infrastructure
├── Repositories
│   └── BooksRepository
├── Seeders
│   └── BookSeeder
```

### **Frontend Folder Structure**
```
src/
├── components
│   ├── Header.vue
│   ├── Footer.vue
│   ├── Sidebar.vue
├── views
│   ├── HomePage.vue
│   ├── BooksPage.vue
│   ├── SignIn.vue
│   └── SignUp.vue
├── utils
│   ├── axios.js
│   └── jwt.js
```

---

## **Database Schema**
### **Books Table**
| Field          | Type        | Description          |
|-----------------|-------------|----------------------|
| `Id`           | `int`       | Primary Key          |
| `Title`        | `nvarchar`  | Title of the book    |
| `Author`       | `nvarchar`  | Author's name        |
| `Genre`        | `nvarchar`  | Genre of the book    |
| `ISBN`         | `nvarchar`  | ISBN number          |
| `PublishedDate`| `datetime`  | Date of publication  |
| `Price`        | `decimal`   | Price of the book    |

### **Users Table**
| Field          | Type        | Description          |
|-----------------|-------------|----------------------|
| `Id`           | `int`       | Primary Key          |
| `Username`     | `nvarchar`  | Username of the user |
| `Email`        | `nvarchar`  | Email address        |
| `Role`         | `nvarchar`  | Role of the user     |
| `PasswordHash` | `nvarchar`  | Encrypted password   |

---

## **API Endpoints**
| Endpoint              | HTTP Method | Description                | Roles       |
|-----------------------|-------------|----------------------------|-------------|
| `/api/books`          | `GET`       | Fetch all books            | All         |
| `/api/books/{id}`     | `GET`       | Fetch book by ID           | All         |
| `/api/books`          | `POST`      | Add a new book             | Admin       |
| `/api/books/{id}`     | `PUT`       | Update a book              | Admin       |
| `/api/books/{id}`     | `DELETE`    | Delete a book              | Admin       |
| `/api/account/login`  | `POST`      | User login                 | All         |
| `/api/account/signup` | `POST`      | User signup                | All         |

---

## **Setup Instructions**
1. Clone the repository:
   ```bash
   git clone https://github.com/arshadahamed/Book-Inventory-Management-System.git
   cd Book-Inventory-Management-System
   ```

2. **Backend Setup**:
   - Navigate to the `BIM.API` folder.
   - Restore dependencies:
     ```bash
     dotnet restore
     ```
   - Update the `appsettings.json` file with your database connection string.
   - Run migrations:
     ```bash
     dotnet ef database update
     ```
   - Start the server:
     ```bash
     dotnet run
     ```

3. **Frontend Setup**:
   - Navigate to the `frontend` folder.
   - Install dependencies:
     ```bash
     npm install
     ```
   - Start the development server:
     ```bash
     npm run dev
     ```

---

## **Testing**
- **Manual Testing**: APIs tested using Postman and Swagger.
- **User Acceptance Testing**: Verified usability across roles.

---

## **Future Enhancements**
- Add additional roles with custom permissions.
- Introduce multi-language support for the frontend.
- Implement analytics to track book inventory trends.

---

## **Screenshots**
[Include project screenshots here once uploaded.]

---

## **License**
This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.
