// =============================
// DATA PERTANYAAN
// =============================
const questions = [
    {
        question: "Tag HTML manakah yang digunakan untuk membuat judul utama?",
        answers: [
            { text: "<h1>", isCorrect: true },
            { text: "<p>", isCorrect: false },
            { text: "<div>", isCorrect: false },
            { text: "<body>", isCorrect: false }
        ]
    },
    {
        question: "Apa fungsi utama dari CSS?",
        answers: [
            { text: "Menambah interaktivitas halaman web", isCorrect: false },
            { text: "Mendefinisikan struktur konten", isCorrect: false },
            { text: "Mengontrol tampilan dan desain elemen", isCorrect: true },
            { text: "Menyimpan data di database", isCorrect: false }
        ]
    },
    {
        question: "Konsep pemrograman apa yang cocok untuk memeriksa jawaban benar atau salah?",
        answers: [
            { text: "Looping (Perulangan)", isCorrect: false },
            { text: "Percabangan (If-Else)", isCorrect: true },
            { text: "Array", isCorrect: false },
            { text: "Function (Fungsi)", isCorrect: false }
        ]
    },
    {
        question: "Pada ide aplikasi QuizQuest, modul Python manakah yang digunakan untuk antarmuka?",
        answers: [
            { text: "random", isCorrect: false },
            { text: "sqlite3", isCorrect: false },
            { text: "Kivy", isCorrect: true },
            { text: "os", isCorrect: false }
        ]
    }
];

// =============================
// ELEMENT DOM
// =============================
const questionElement = document.getElementById("question-text");
const answerButtons = document.getElementById("answer-buttons");
const nextButton = document.getElementById("next-btn");
const scoreDisplay = document.getElementById("score-display");
const quizArea = document.getElementById("quiz-area");
const resultArea = document.getElementById("result-area");
const finalScoreDisplay = document.getElementById("final-score");
const restartButton = document.getElementById("restart-btn");

// STATUS KUIS
let currentQuestionIndex = 0;
let score = 0;
let answered = false;

// =============================
// MULAI KUIS
// =============================
function startQuiz() {
    currentQuestionIndex = 0;
    score = 0;
    answered = false;

    scoreDisplay.textContent = score;
    resultArea.classList.add('hidden');
    quizArea.classList.remove('hidden');

    nextButton.classList.remove('hidden');
    nextButton.textContent = "Lanjut";

    // Acak pertanyaan
    questions.sort(() => Math.random() - 0.5);

    showQuestion();
}

// =============================
// TAMPILKAN PERTANYAAN
// =============================
function showQuestion() {
    resetState();

    const currentQuestion = questions[currentQuestionIndex];
    questionElement.textContent = `${currentQuestionIndex + 1}. ${currentQuestion.question}`;

    // Acak jawaban
    const shuffledAnswers = [...currentQuestion.answers].sort(() => Math.random() - 0.5);

    shuffledAnswers.forEach(answer => {
        const button = document.createElement("button");
        button.textContent = answer.text;
        button.classList.add("btn");
        if (answer.isCorrect) button.dataset.correct = "true";

        button.addEventListener("click", selectAnswer);
        answerButtons.appendChild(button);
    });

    nextButton.classList.add('hidden');

    // Jika pertanyaan terakhir, ganti tulisan
    if (currentQuestionIndex === questions.length - 1) {
        nextButton.textContent = "Lihat Hasil";
    }
}

// =============================
// HAPUS STATE SEBELUMNYA
// =============================
function resetState() {
    answerButtons.innerHTML = "";
    answered = false;
}

// =============================
// PROSES JAWABAN
// =============================
function selectAnswer(e) {
    if (answered) return;

    const selectedBtn = e.target;
    const isCorrect = selectedBtn.dataset.correct === "true";

    if (isCorrect) {
        selectedBtn.classList.add("correct");
        score += 10;
        scoreDisplay.textContent = score;
    } else {
        selectedBtn.classList.add("incorrect");
    }

    // Tampilkan jawaban benar
    Array.from(answerButtons.children).forEach(btn => {
        if (btn.dataset.correct === "true") {
            btn.classList.add("correct");
        }
        btn.disabled = true;
    });

    nextButton.classList.remove('hidden');
    answered = true;
}

// =============================
// TOMBOL LANJUT
// =============================
function handleNextButton() {
    if (!answered) return;

    currentQuestionIndex++;
    if (currentQuestionIndex < questions.length) {
        showQuestion();
    } else {
        showScore();
    }
}

// =============================
// TAMPILKAN HASIL AKHIR
// =============================
function showScore() {
    quizArea.classList.add('hidden');
    nextButton.classList.add('hidden');

    finalScoreDisplay.textContent = score;
    resultArea.classList.remove('hidden');
}

// =============================
// EVENT LISTENER
// =============================
nextButton.addEventListener("click", handleNextButton);
restartButton.addEventListener("click", startQuiz);

// =============================
// MULAI OTOMATIS
// =============================
startQuiz();
