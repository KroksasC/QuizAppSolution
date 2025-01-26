import { useEffect, useState } from 'react';
import Quiz from './Quiz';

const QuizPage = () => {
    const [quizQuestions, setQuizQuestions] = useState([]);

    useEffect(() => {
        async function populateQuizData() {
            try {
                const response = await fetch('quizquestions');
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                const data = await response.json();
                setQuizQuestions(data);
            } catch (error) {
                console.error('Error fetching quiz questions:', error);
            }
        }
        populateQuizData();
    }, []);

    return (
        <div>
            {quizQuestions.length > 0 ? (
                <Quiz questions={quizQuestions} />
            ) : (
                <h1>Loading questions... Try to reload.</h1>
            )}
        </div>
    );
};

export default QuizPage;
