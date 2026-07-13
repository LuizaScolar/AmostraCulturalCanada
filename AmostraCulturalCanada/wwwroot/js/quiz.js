const questions = [
    {
        question: "Qual é o verdadeiro esporte raiz canadense, criado pelos povos algonquianos?",
    options: ["Hóquei no Gelo", "Lacrosse", "Futebol Americano", "Curling"],
    correctAnswer: 1
        },
    {
        question: "O que é o Pemmican, tradicional alimento de sobrevivência?",
    options: ["Uma bebida de ervas", "Um pão doce frito", "Mistura de carne seca, gordura e mirtilos", "Sopa de peixe"],
    correctAnswer: 2
        },
    {
        question: "Na lenda 'La Chasse-galerie', o que os madeireiros fizeram voar?",
    options: ["Um trenó de cães", "Uma canoa", "Um machado mágico", "Uma cabana"],
    correctAnswer: 1
        },
    {
        question: "Na mitologia Inuit, qual criatura vive nas águas congeladas do Ártico?",
    options: ["Wendigo", "Ogopogo", "Qalupalik", "Sasquatch"],
    correctAnswer: 2
        },
    {
        question: "Qual tradição musical envolve duas mulheres cantando frente a frente produzindo sons guturais?",
    options: ["Fiddle Music", "Powwow", "Canto de Garganta (Throat Singing)", "Jigging"],
    correctAnswer: 2
        }
    ];

    let currentQuestionIndex = 0;
    let score = 0;
    let selectedOptionIndex = -1;

    function loadQuestion() {
        const q = questions[currentQuestionIndex];
    document.getElementById('questionText').innerText = `Pergunta ${currentQuestionIndex + 1}: ${q.question}`;
    const optionsArea = document.getElementById('optionsArea');
    optionsArea.innerHTML = '';
    selectedOptionIndex = -1;
    document.getElementById('btnNext').style.display = 'none';

        q.options.forEach((opt, index) => {
            const btn = document.createElement('button');
    btn.className = 'option-btn';
    btn.innerText = opt;
            btn.onclick = () => selectOption(index, btn);
    optionsArea.appendChild(btn);
        });
    }

    function selectOption(index, buttonElement) {
        selectedOptionIndex = index;
    const buttons = document.querySelectorAll('.option-btn');
        buttons.forEach(btn => btn.classList.remove('selected'));
    buttonElement.classList.add('selected');
    document.getElementById('btnNext').style.display = 'inline-block';
    if (currentQuestionIndex === questions.length - 1) {
        document.getElementById('btnNext').innerText = 'Ver Resultado Final';
        }
    }

    function nextQuestion() {
        if (selectedOptionIndex === questions[currentQuestionIndex].correctAnswer) {score++; }
    currentQuestionIndex++;
    if (currentQuestionIndex < questions.length) {loadQuestion(); } else {showResult(); }
    }

    function showResult() {
        document.getElementById('quizArea').style.display = 'none';
    document.getElementById('quizHeader').style.display = 'none';
    document.getElementById('resultArea').style.display = 'block';
    document.getElementById('scoreDisplay').innerText = `${score}/${questions.length}`;
    const feedback = document.getElementById('feedbackText');
    if(score === 5) feedback.innerText = "Perfeito! É um verdadeiro especialista na cultura raiz canadense!";
        else if(score >= 3) feedback.innerText = "Muito bom! Absorveu bem o conhecimento da nossa pesquisa.";
    else feedback.innerText = "Foi por pouco! Que tal dar mais uma leitura nas páginas de Cultura e Folclore?";
    }

    window.onload = loadQuestion;