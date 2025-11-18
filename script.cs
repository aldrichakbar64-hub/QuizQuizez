// Data Pertanyaan (Contoh mata pelajaran Informatika)
const questions = [
    {
        question: "Tag HTML manakah yang digunakan untuk membuat judul utama?",
        answers: [
            { text: "<h1>", isCorrect: true },
            { text: "<p>", isCorrect: false },
            { text: "<div>", isCorrect: false },
            { text: "<body>", isCorrect: false },
        ]
    },
    {
        question: "Apa fungsi utama dari CSS?",
        answers: [
            { text: "Menambah interaktivitas halaman web", isCorrect: false },
            { text: "Mendefinisikan struktur konten", isCorrect: false },
            { text: "Mengontrol tampilan dan desain elemen", isCorrect: true },
            { text: "Menyimpan data di database", isCorrect: false },
        ]
    },
    {
        question: "Konsep pemrograman apa yang cocok untuk memeriksa jawaban benar atau salah?",
        answers: [
            { text: "Looping (Perulangan)", isCorrect: false },
            { text: "Percabangan (If-Else)", isCorrect: true },
            { text: "Array", isCorrect: false },
            { text: "Function (Fungsi)", isCorrect: false },
        ]
    },
    {
        question: "Pada ide aplikasi QuizQuest, modul Python manakah yang digunakan untuk antarmuka?",
        answers: [
            { text: "random", isCorrect: false },
            { text: "sqlite3", isCorrect: false },
            { text: "Kivy", isCorrect: true },
            { text: "os", isCorrect: false },
        ]
    },
];

// Elemen DOM
const questionElement = document.getElementById("question-text");
const answerButtons = document.getElementById("answer-buttons");
const nextButton = document.getElementById("next-btn");
const scoreDisplay = document.getElementById("score-display");
const quizArea = document.getElementById("quiz-area");
const resultArea = document.getElementById("result-area");
const finalScoreDisplay = document.getElementById("final-score");
const restartButton = document.getElementById("restart-btn");

// Variabel Status Kuis
let currentQuestionIndex = 0;
let score = 0;
let answered = false;

// --- Fungsi Utama Kuis ---

// 1. Memulai Kuis
function startQuiz() {
    // Reset status
    currentQuestionIndex = 0;
    score = 0;
    answered = false;
    scoreDisplay.textContent = score;

    // Tampilan awal
    resultArea.classList.add('hidden');
    quizArea.classList.remove('hidden');
    nextButton.classList.remove('hidden');
    nextButton.textContent = "Lanjut";
    
    // Acak urutan pertanyaan
    questions.sort(() => Math.random() - 0.5); 
    
    showQuestion();
}

// 2. Menampilkan Pertanyaan
function showQuestion() {
    resetState();
    
    // Ambil pertanyaan saat ini
    let currentQuestion = questions[currentQuestionIndex];
    let questionNo = currentQuestionIndex + 1;
    questionElement.innerHTML = questionNo + ". " + currentQuestion.question;

    // Acak urutan jawaban
    let shuffledAnswers = [...currentQuestion.answers].sort(() => Math.random() - 0.5);

    // Tampilkan tombol jawaban
    shuffledAnswers.forEach(answer => {
        const button = document.createElement("button");
        button.innerHTML = answer.text;
        button.classList.add("btn");
        // Simpan status koreksi di dataset
        if (answer.isCorrect) {
            button.dataset.correct = "true";
        }
        button.addEventListener("click", selectAnswer);
        answerButtons.appendChild(button);
    });

    // Sembunyikan tombol Lanjut jika belum dijawab
    nextButton.classList.add('hidden');

    // Ubah teks tombol jika ini adalah pertanyaan terakhir
    if (currentQuestionIndex === questions.length - 1) {
        nextButton.textContent = "Lihat Hasil";
    }
}

// 3. Membersihkan Status Tombol Jawaban
function resetState() {
    // Hapus semua tombol jawaban sebelumnya
    while (answerButtons.firstChild) {
        answerButtons.removeChild(answerButtons.firstChild);
    }
    nextButton.classList.add('hidden');
    answered = false;
}

// 4. Memproses Jawaban
function selectAnswer(e) {
    if (answered) return; // Mencegah klik ganda
    
    const selectedBtn = e.target;
    const isCorrect = selectedBtn.dataset.correct === "true";

    // 1. Beri Feedback Visual (Inovasi/Keunikan: Sistem Poin)
    if (isCorrect) {
        selectedBtn.classList.add("correct");
        score += 10; // Tambah 10 Poin
        scoreDisplay.textContent = score;
    } else {
        selectedBtn.classList.add("incorrect");
    }

    // 2. Tunjukkan jawaban yang benar jika ada jawaban yang salah
    Array.from(answerButtons.children).forEach(button => {
        if (button.dataset.correct === "true") {
            button.classList.add("correct");
        }
        // Nonaktifkan semua tombol setelah menjawab
        button.disabled = true;
    });

    // 3. Tampilkan tombol Lanjut
    nextButton.classList.remove('hidden');
    answered = true;
}

// 5. Memproses Tombol Lanjut
function handleNextButton() {
    currentQuestionIndex++;
    if (currentQuestionIndex < questions.length) {
        showQuestion();
    } else {
        showScore();
    }
}

// 6. Menampilkan Hasil Akhir
function showScore() {
    quizArea.classList.add('hidden');
    nextButton.classList.add('hidden');

    finalScoreDisplay.textContent = score;
    resultArea.classList.remove('hidden');
}

// --- Event Listeners ---
nextButton.addEventListener("click", () => {
    if (currentQuestionIndex < questions.length) {
        handleNextButton();
    } else {
        startQuiz(); // Seharusnya tidak terpanggil di sini jika logic benar, tapi sebagai fallback
    }
});

restartButton.addEventListener("click", startQuiz);

// --- Inisialisasi ---
startQuiz();
