<div align="center">

# 🐦 Flappy Bird

### A Classic 2D Arcade Game Recreated from Scratch in Unity 6

<p>
A faithful recreation of one of the most iconic arcade games ever made—built entirely from scratch using <b>Unity 6</b> and <b>C#</b>.
</p>

<br>

![Unity](https://img.shields.io/badge/Unity-6-000000?style=for-the-badge&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-Programming-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows)
![Status](https://img.shields.io/badge/Status-Completed-2ea44f?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

<br><br>

🎮 **[Download Game](YOUR_GAME_LINK)** • 📄 **[Project Report](YOUR_REPORT_LINK)**

</div>

---

# 🎯 About The Project

Flappy Bird is one of the simplest games to play—but recreating it properly requires much more than making a bird jump.

This project is a **complete recreation of the original Flappy Bird**, developed entirely from scratch in **Unity 6** using **C#**.

Rather than following a tutorial line-by-line, the objective was to understand how every gameplay system works internally and implement it independently.

The project demonstrates:

- Physics-based character movement
- Event-driven gameplay
- Procedural obstacle spawning
- Game state management
- Persistent leaderboard storage
- Clean Unity architecture
- UI state transitions

The result is a polished Windows desktop game featuring an authentic gameplay experience with a modular architecture that serves as a strong foundation for future Unity projects.

---

# 🎥 Gameplay

> **Add your gameplay GIF here**

```
assets/gameplay.gif
```

*A short gameplay GIF instantly makes the repository far more engaging.*

---

# ✨ Features

## 🎮 Gameplay

- Physics-based bird movement
- Endless side-scrolling gameplay
- Random obstacle generation
- Real-time score tracking
- Responsive collision detection
- Authentic Flappy Bird feel

---

## ⚙️ Game Systems

- Three-state game loop

  - Start Menu
  - Gameplay
  - Game Over

- Singleton Game Manager
- Event-driven scripting
- Automatic obstacle destruction
- Object lifecycle management

---

## 💾 Persistence

- Automatic score saving
- Best score tracking
- Persistent Top-5 leaderboard
- PlayerPrefs data storage

---

## 🖥️ User Interface

- Start Menu
- Pause using Time.timeScale
- Game Over panel
- Live score display
- Best score display
- Medal system 🥇🥈🥉

---

# 📸 Screenshots

| Gameplay | Game Over |
|----------|-----------|
| Add Screenshot | Add Screenshot |

---

# 🏗 Architecture

```
            +----------------------+
            |    GameManager       |
            +----------------------+
                    |    |           
                    |    |           
                    |    |           
              Score |    | Game State
                    |    |
                    ↓    ↓
              +-----------------+
              | PlayerController|
              +-----------------+
                      |
               Collision Events
                      |
                      ↓
               Trigger Game Over

                      ↑

              +-----------------+
              |     Pipes       |
              +-----------------+
                      |
              Spawn Every 2 Seconds
                      |
                 Random Height
```

The game follows a clean **three-state architecture**, ensuring each gameplay phase remains independent and easy to maintain.

---

# 🔄 Game Flow

```
Start Menu

↓

Player Presses Play

↓

Gameplay Starts

↓

Spawn Pipes Every 2 Seconds

↓

Player Scores

↓

Collision Detected

↓

Game Over

↓

Leaderboard Updated

↓

Play Again
```

---

# 🧠 Technical Highlights

## Physics

- Rigidbody2D
- Gravity tuning
- Jump impulse balancing

---

## Collision System

- Obstacle collision
- Ground collision
- Trigger zones
- Score detection

---

## UI Management

- Canvas
- TextMeshPro
- Dynamic panel switching
- Live score updates

---

## Data Persistence

Player scores are stored locally using **PlayerPrefs**.

Features include

- Best Score
- Top 5 Leaderboard
- Automatic sorting
- Persistent storage

---

# 📂 Project Structure

```
FlappyBird/

│

├── Assets/

│ ├── Scripts/

│ │ ├── GameManager.cs

│ │ ├── PlayerController.cs

│ │ └── Speed.cs

│

├── Prefabs/

├── Sprites/

├── Scenes/

├── UI/

└── README.md
```

---

# 🧩 Script Responsibilities

| Script | Responsibility |
|---------|---------------|
| **GameManager.cs** | Controls the entire game loop, obstacle spawning, score system, UI transitions, leaderboard, and persistent storage. |
| **PlayerController.cs** | Handles bird movement, user input, collision detection, and scoring events. |
| **Speed.cs** | Moves obstacles and scrolling elements across the screen. |

---

# 🚧 Challenges & Solutions

## Physics Tuning

Finding the correct balance between gravity and jump force required multiple iterations before achieving gameplay that felt responsive without becoming frustrating.

---

## Obstacle Management

Pipes are spawned procedurally and automatically destroyed after leaving the screen, preventing unnecessary memory usage.

---

## Duplicate Game Over Events

Multiple collisions could trigger Game Over more than once.

A guard clause prevents duplicate execution.

```csharp
if (isGameOver)
    return;
```

---

## Persistent Leaderboard

Scores are

- Sorted automatically
- Limited to Top 5
- Saved using PlayerPrefs
- Loaded every game session

---

# 💡 Engineering Decisions

## Singleton Pattern

A Singleton GameManager was used because only one central authority should manage

- Game State
- Score
- UI
- Obstacle Spawning
- Leaderboard

This removes duplicate state management and simplifies communication between scripts.

---

## Event-Driven Architecture

Instead of every object managing everything independently,

PlayerController notifies GameManager,

and GameManager decides what happens next.

This keeps responsibilities separated and the codebase easier to maintain.

---

# 📊 Technologies Used

| Category | Technology |
|----------|------------|
| Engine | Unity 6 |
| Language | C# |
| IDE | Visual Studio |
| Physics | Rigidbody2D |
| UI | TextMeshPro |
| Persistence | PlayerPrefs |
| Pattern | Singleton |
| Platform | Windows Standalone |

---

# 📈 Project Highlights

✅ Built entirely from scratch

✅ Unity 6

✅ C#

✅ Physics-based gameplay

✅ Procedural obstacle generation

✅ Singleton architecture

✅ Event-driven scripting

✅ PlayerPrefs persistence

✅ Dynamic UI

✅ Top-5 leaderboard

---

# 📚 What I Learned

This project strengthened my understanding of

- Unity 2D workflow
- Physics2D
- Rigidbody2D
- BoxCollider2D
- Trigger Zones
- MonoBehaviour lifecycle
- Object instantiation
- Object destruction
- Singleton Pattern
- Event-driven programming
- UI development
- Game state management
- Persistent data storage
- Clean project architecture

---

# 🚀 Future Improvements

- Sound effects
- Background music
- Difficulty progression
- Mobile controls
- Android build
- Animated backgrounds
- Power-ups
- Cloud leaderboard
- Achievement system

---

# ⚙️ Getting Started

## Clone the Repository

```bash
git clone https://github.com/yourusername/flappy-bird.git
```

Open the project using

```
Unity 6 (6000.3.8f1)
```

Press **Play** inside Unity.

---

# 🎮 Controls

| Key | Action |
|-----|--------|
| Space | Flap |
| Mouse | UI Buttons |

---

# 👨‍💻 Author

## Polikey Bhuvan

**B.Tech Computer Science & Engineering**

Passionate about

- Game Development
- AI
- Software Engineering
- Unity Development

---

## 🤝 Connect With Me

<p align="center">

<a href="https://github.com/polikeybhuvan">
<img src="https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white"/>
</a>

<a href="https://linkedin.com/in/polikeybhuvan">
<img src="https://img.shields.io/badge/LinkedIn-0A66C2?style=for-the-badge&logo=linkedin&logoColor=white"/>
</a>

<a href="https://polikey-bhuvan.onrender.com">
<img src="https://img.shields.io/badge/Portfolio-000000?style=for-the-badge&logo=googlechrome&logoColor=white"/>
</a>

<a href="mailto:your@email.com">
<img src="https://img.shields.io/badge/Email-EA4335?style=for-the-badge&logo=gmail&logoColor=white"/>
</a>

</p>
<div align="center">

### ⭐ If you enjoyed this project, consider giving the repository a star!

Made with ❤️ using Unity 6 & C#

</div>
