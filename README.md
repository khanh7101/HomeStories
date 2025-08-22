# 📚 HomeStories


**HomeStories** is a web application for reading and sharing both comics and novels.
A diverse library of comics and novels with a wide range of genres. Discover, read, and share your favorite stories — from romance, action, thriller to comedy. With a modern and friendly interface, the website is designed for high school students, university learners, and story lovers of all ages.


---


## 👥 Implementation Team
- **Team:** ****** (class code: XXX)
- **Members:**


- ******** – Team Leader


- ******** – Backend


- ******** – Frontend


- ******** – Database


- ******** – QA & Documentation


---


## 🚀 Features


- 👥 User authentication (register, login, manage profile)  
- 📖 Browse and read stories (both text & comics)  
- 🔍 Search and filter stories by genre, author, popularity  
- ⭐ Follow favorite stories & authors  
- 💬 Comment and interact with other readers  
- 📱 Responsive design for desktop and mobile  


---
## 🛠 Tech Stack


### Backend (BE)
- **.NET 9.0** (ASP.NET Core Web API)  
- **MySQL** database  
- **Entity Framework Core** (ORM)  
- **Swagger** for API documentation  


### Frontend (FE)
- **React + Vite**  
- **TailwindCSS** for styling  
- **Axios** for API calls  


### Collaboration & Tools
- **GitHub Project** (Kanban board, issues, PRs)  
- **Postman / Swagger** (API testing & mocking)


---


## 📂 Project Structure


HomeStories/
│── HomeStoriesAPI/ # Backend (C#, ASP.NET Core, MySQL)
│── homestories-fe/ # Frontend (React + TailwindCSS)
│── docs/ # Reports, project documents
│── README.md # Project documentation




---


## ⚙️ Setup Instructions


### 1. Clone repository


    ```bash
    git clone https://github.com/khanh7101/HomeStories.git
    cd HomeStories
    ```


### 2. Backend (HomeStoriesAPI)


    ```bash
    cd HomeStoriesAPI
    dotnet restore
    dotnet ef database update   # create database schema
    dotnet run
    ```
    Backend runs at: http://localhost:5000


### 3. Frontend (homestory-fe)


    ```bash
    cd homestory-fe
    npm install
    npm run dev
    ```
    Frontend runs at: http://localhost:5173


---


## 📑 API Documentation


Swagger UI: http://localhost:5000/swagger


Mock API: via Postman or SwaggerHub ( for FE testing before BE is ready )


---


## 🧑‍🤝‍🧑 Team Structure


Backend Team (BE): API, database, authentication, business logic


Frontend Team (FE): UI/UX, React components, integration with API


---


## ✍️ Coding Conventions


### General


   - Code must be clean, readable, consistent


   - English for variable/method names


### Backend (C#)


   - Classes & Methods: PascalCase


   - Variables & Parameters: camelCase


   - DTOs/Entities: meaningful names (e.g., UserDto, StoryEntity)


### Frontend (React)


   - Components: PascalCase (e.g., UserProfile.js)


   - Variables/Functions: camelCase


   - Hooks: useSomething naming


### Branch Naming


   - feature/<name> → new features


   - fix/<name> → bug fixes


   - hotfix/<name> → urgent fixes


### Commit Message Convention


    - feat: new feature
    - fix: bug fix
    - docs: documentation update
    - style: code formatting (no logic change)
    - refactor: code restructuring
    - test: adding or updating tests
    - chore: maintenance tasks


### Pull Requests


    - Must describe changes clearly


    - Link to related issue/task


    - Require at least 1 reviewer approval before merging


## 📌 Contribution Workflow


    1. Pick a task from GitHub Project


    2. Create a new branch from main


    3. Commit changes following convention


    4. Push & create Pull Request


    5. Request review → Merge after approval


## 📊 Project Tracking


    - Tasks & Schedule: GitHub Projects (Kanban board)


    - Issues & Bugs: GitHub Issues


    - Documentation: /docs folder + README



