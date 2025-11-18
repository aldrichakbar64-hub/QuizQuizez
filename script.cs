/* =========================
   GLOBAL RESET & FONT
========================= */
* {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

body {
    background: linear-gradient(135deg, #1f4068, #162447);
    color: #f7f7f7;
    font-family: 'Poppins', sans-serif;
    display: flex;
    justify-content: center;
    align-items: center;
    min-height: 100vh;
    padding: 20px;
}

/* =========================
   CONTAINER
========================= */
.container {
    background-color: #1b1b2f;
    padding: 30px;
    border-radius: 15px;
    box-shadow: 0 10px 25px rgba(0,0,0,0.5);
    width: 100%;
    max-width: 600px;
    text-align: center;
}

/* =========================
   HEADER
========================= */
header h1 {
    font-size: 2.5em;
    margin-bottom: 5px;
}

.highlight {
    color: #e43f5a;
}

header p {
    font-size: 1.1em;
    margin-bottom: 15px;
}

hr {
    border: none;
    height: 1px;
    background-color: rgba(255,255,255,0.2);
    margin: 20px 0;
}

/* =========================
   QUIZ AREA
========================= */
#question-text {
    font-size: 1.4em;
    margin-bottom: 25px;
    color: #f7f7f7;
    min-height: 50px;
}

/* =========================
   ANSWER BUTTONS
========================= */
#answer-buttons {
    display: grid;
    grid-template-columns: 1fr 1fr;
    gap: 15px;
    margin-bottom: 25px;
}

.btn {
    background-color: #3b6978;
    color: #f7f7f7;
    border: none;
    padding: 15px;
    border-radius: 8px;
    cursor: pointer;
    font-size: 1em;
    transition: background-color 0.2s ease, transform 0.1s ease;
}

.btn:hover:not(.correct):not(.incorrect):not(:disabled) {
    background-color: #4a8091;
    transform: translateY(-2px);
}

.btn:disabled {
    cursor: not-allowed;
    opacity: 0.7;
}

/* =========================
   FEEDBACK (BENAR/SALAH)
========================= */
.correct {
    background-color: #27ae60 !important;
    color: white;
}

.incorrect {
    background-color: #c0392b !important;
    color: white;
}

/* =========================
   NEXT & RESTART BUTTON
========================= */
#next-btn,
#restart-btn {
    background-color: #e43f5a;
    color: white;
    padding: 12px 30px;
    border: none;
    border-radius: 8px;
    cursor: pointer;
    font-size: 1.1em;
    margin-top: 15px;
    transition: background-color 0.2s ease;
}

#next-btn:hover,
#restart-btn:hover {
    background-color: #d1304d;
}

/* =========================
   RESULT AREA
========================= */
#result-area h2 {
    font-size: 2em;
    color: #e43f5a;
    margin-bottom: 10px;
}

#result-area p {
    font-size: 1.2em;
    margin-bottom: 20px;
}

/* =========================
   UTILITIES
========================= */
.hidden {
    display: none !important;
}
