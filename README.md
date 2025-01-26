 Quiz Web Application

This web application allows users to take a quiz and view the high scores from previous results. It consists of two main pages: one for answering the quiz questions and another for displaying the top high scores.

## Functional Requirements

### Quiz Page:
- The quiz contains 10 questions.
- The questions are categorized into 3 types:
  - **Radio buttons** (single-answer questions)
  - **Checkbox** (multiple-answer questions)
  - **Textbox** (manual text input)
- The quiz includes:
  - 4 single-answer (radio) questions
  - 2 text input questions
  - 4 multiple-answer (checkbox) questions
- Users must enter their **Email** while taking the quiz, which will be saved along with their score.

### High Score Page:
- Displays the top 10 high scores.
- Each entry shows:
  - **Position**
  - **Email**
  - **Score**
- The top 3 positions are highlighted with **gold**, **silver**, and **bronze** colors.

### Scoring Calculation:
- **Radio buttons**: A correct answer earns +100 points.
- **Checkbox**: The score is calculated as `(100 / number of correct answers) * number of correct answers selected`, rounded to the nearest whole number (no decimals).
- **Textbox**: A correct answer earns +100 points if the answer matches exactly (case insensitive).

## Technical Requirements

- **Backend**: 
  - Developed using **ASP.NET Core**.
  - Utilizes **Entity Framework Core** with an **in-memory database** to store quiz entries, answers, and high scores.
  - All quiz logic and score calculations are handled on the server side.
  
- **Frontend**: 
  - Built with **React**.
 
