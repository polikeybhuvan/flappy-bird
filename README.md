<div align="center">

# 🐦 Flappy Bird
### A Classic 2D Side-Scrolling Game — Rebuilt from Scratch in Unity 6

![Unity](https://img.shields.io/badge/Unity%206-000000?style=flat-square&logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Windows%20Standalone-0078D6?style=flat-square&logo=windows&logoColor=white)
![Status](https://img.shields.io/badge/Status-Complete-3fb950?style=flat-square)

🎮 **[Download & Play the Game](https://drive.google.com/file/d/1sv-G3rRYkOEEf2EZqmJeTicc7UhrmKic/view?usp=sharing)** &nbsp;·&nbsp; 📄 **[Read the Full Project Report](https://drive.google.com/file/d/1DB0Lqq7OpTAKe8l3Sb1ocDvvv6iNY26C/view?usp=sharing)**

</div>

---

### // overview

> Everyone knows Flappy Bird. Almost no one has *built* it.

This project recreates Dong Nguyen's 2013 classic from the ground up in **Unity 6** — not a copy-paste tutorial follow-along, but a from-scratch implementation covering Physics 2D, event-driven scripting, UI state machines, and persistent data storage. Three scripts, one Singleton architecture, zero external asset dependencies.

<br>

### // what it does

```
> tap SPACE             → bird flaps upward against gravity
> survive pipes         → dynamic, randomised obstacle spawning every 2s
> clear a gap           → live score increments via trigger zones
> hit something         → Game Over, score saved permanently
> beat your best        → Top-5 leaderboard, medals for top 3, PlayerPrefs-backed
```

<br>

### // tech stack

| Layer | Tools |
|---|---|
| Engine | Unity 6 (6000.3.8f1) |
| Language | C# — Mono / IL2CPP |
| Physics | Rigidbody2D · BoxCollider2D · Trigger Zones |
| UI | Canvas · TextMeshPro |
| Persistence | PlayerPrefs |
| Architecture | Singleton pattern, event-driven collision handling |

<br>

### // code

The full source is in this repo — three scripts, each with a single clear responsibility:

| File | Responsibility |
|---|---|
| [`GameManager.cs`](./GameManager.cs) | Singleton controller — obstacle spawning, UI state transitions, score tracking, leaderboard save/load |
| [`PlayerController.cs`](./PlayerController.cs) | Bird input (space to flap), collision detection, score-trigger handling |
| [`Speed.cs`](./Speed.cs) | Scrolls obstacles and background leftward at a constant rate |

<br>

### // architecture

**Scene Hierarchy:** Game Manager · Player · Background · Ground · Main Camera · Global Light 2D · Canvas (Start Menu / Game Over / Score) · Event System

**Game Loop — 3 States:**

```
STATE 1  Start Menu      Time.timeScale = 0f   →  Play / Exit buttons
STATE 2  Gameplay        Time.timeScale = 1f   →  pipes spawn @ 2s, score live
STATE 3  Game Over       collision detected    →  score saved, leaderboard shown
```

<br>

### // challenges & how they were solved

| Challenge | Solution |
|---|---|
| Gravity & jump feel | Iteratively tuned Rigidbody2D gravity scale + jump impulse |
| Pipe spawn clutter | `Destroy(obs, 5f)` + distinct `Obstacle` / `ScoreZone` tags |
| Score UI syncing with game state | Centralised visibility control via GameManager |
| Leaderboard persistence | PlayerPrefs, sorted descending, capped at 5, medals rebuilt each run |
| Duplicate Game Over triggers | Guard clause: `if (isGameOver) return;` |

<br>

### // skills exercised

`Unity 2D Workflow` `Physics2D` `Collider Triggers` `Singleton Pattern` `Event-Driven Scripting` `TextMeshPro UI` `PlayerPrefs Persistence` `Game Loop Architecture`

<br>

### // outcomes

- ✅ Fully functional 3-state game loop, built and shipped as a Windows standalone
- ✅ Physics-accurate bird movement matching the original's "feel"
- ✅ Randomised obstacle spawning — a new run every time
- ✅ Persistent Top-5 leaderboard that survives restarts
- ✅ Clean Singleton architecture — no race conditions, no duplicate instances

<br>

---

<div align="center">

**Polikey Bhuvan** — B.Tech CSE, Centurion University of Technology & Management

[Portfolio](https://polikey-bhuvan.onrender.com) · [LinkedIn](https://linkedin.com/in/polikeybhuvan) · [GitHub](https://github.com/polikeybhuvan)

</div>
