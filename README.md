# 🎮 Who Wants to Be a Millionaire? (Console Edition)

A console-based remake of *Who Wants to Be a Millionaire?* built in C#.  
This project was made for fun in ~4 days as an experiment to push the limits of what’s possible in the console window — colors, animations, sounds, and more.

<p align="center">
  <img src="https://github.com/user-attachments/assets/f3c61c64-fb24-405a-b1ba-3b8eb247b45f" alt="Game Screenshot" width="500"/>
</p>


---

## ✨ Features

- 🎭 **Animated Jokers** — 50:50, Ask the Audience, Phone a Friend, and Double Answer appear with console animations.  
- 💰 **Money Tree with Live Indicator** — shows your progress through all 15 questions.  
- 🟨 **Suspense Highlights** — selected answers turn yellow, and the correct one flashes green 3 times (like the real show).  
- 🔤 **Big ASCII Screens** — used for the start screen and end game for a more dramatic look.  
- ⏳ **Countdown Timer** — colored dots turn from green → yellow → red, with beeps for extra tension.  
- 🎵 **Beep Sounds** — suspense and timing feedback using `Console.Beep()`.

---

## 🛠️ Tech

- **Language:** C#  
- **Platform:** Console Application (.NET)  
- **Concepts Used:**  
  - `Console.SetCursorPosition` for layout/animations  
  - `Console.ForegroundColor` / `Console.BackgroundColor` for colors  
  - `Thread.Sleep` for animation timing  
  - `Console.Beep` for sound effects  
  - Asynchronous input & timers with `Task.Run` and `CancellationToken` for parallel input handling and countdown  
  - **OOP principles** (see below 👇)

---

## 🧩 OOP Design

Although this was mainly a console experiment, the project applies object-oriented design principles:

- **Encapsulation** →  
  `Question` class stores question text, options, and answer checking.  
  `Joker` class generates visual joker models.

- **Modularity** →  
  Separate classes handle questions (`QuizData`), game flow (`UIwithLogic`), screens (`MainMenu`, `EndScreen`), and progress tracking.

- **Abstraction** →  
  Game logic calls methods like `Joker.JokerModel()` or `Progress.ResultMarker()` without needing to know their inner details.

---

## 🚀 How to Play

1. **Clone this repo**  

```bash
git clone https://github.com/canonbas03/ConsoleQuizApp.git
cd ConsoleQuizApp
