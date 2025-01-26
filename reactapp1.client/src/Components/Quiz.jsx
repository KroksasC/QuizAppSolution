import { useState } from 'react';
import './Quiz.css';
import PropTypes from 'prop-types';
import Swal from 'sweetalert2';

const Quiz = ({ questions }) => {

    const [email, setEmail] = useState(""); 
    const [index, setIndex] = useState(0);
    const [answers, setAnswers] = useState({}); 
    const handleChange = (questionId, value) => {
        setAnswers((prevAnswers) => ({
            ...prevAnswers,
            [questionId]: value,
        }));
    };

    const handleCheckboxChange = (questionId, value) => {
        setAnswers((prevAnswers) => {
            const prevValues = prevAnswers[questionId] || [];

            if (prevValues.includes(value)) {
                return {
                    ...prevAnswers,
                    [questionId]: prevValues.filter((v) => v !== value),
                };
            } else {
                return {
                    ...prevAnswers,
                    [questionId]: [...prevValues, value],
                };
            }
        });
    };

    const handleNext = () => {
        if (index < questions.length - 1) {
            setIndex(index + 1);
        }
    };

    const handlePrevious = () => {
        if (index > 0) {
            setIndex(index - 1);
        }
    };

    const handleSubmit = async () => {
        const gmailRegex = /^[a-zA-Z0-9._%+-]+@gmail\.com$/;
        const isGmail = (email) => gmailRegex.test(email);
        if (!email || !isGmail(email)) {
            await Swal.fire({
                title: "Failure!",
                text: "Email entered incorrectly!",
                icon: "error",
                confirmButtonText: "OK",
            });
            return;
        }
        const answersList = Object.keys(answers).map(key => {
            const answer = answers[key];
            return Array.isArray(answer) ? answer.join(', ') : answer;
        });

        const payload = {
            email,
            answers: answersList,
        };

        try {
            const response = await fetch("users", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(payload),
            });

            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            await Swal.fire({
                title: "Success!",
                text: "Your submission was successful, your result will be presented on the dashboard page!",
                icon: "success",
                confirmButtonText: "OK",
            });
            window.location.reload();
            
        } catch (error) {
            console.error("Error submitting quiz:", error);
            await Swal.fire({
                title: "Failure!",
                text: "Failed to submit!",
                icon: "error",
                confirmButtonText: "OK",
            });
        }
    };

    const question = questions[index];

    return (
        <div className="Questions">
            <h1>Quiz App</h1>
            <hr />
            <h2>{question.questionText}</h2>
            <h4>Question {index + 1}/10</h4>
            {question.questionType === 'Radio' && (
                <div>
                    {question.options?.map((option, idx) => (
                        <label key={idx}>
                            <input
                                type="radio"
                                name={`question-${question.id}`}
                                value={option}
                                checked={answers[question.id] === option}
                                onChange={(e) =>
                                    handleChange(question.id, e.target.value)
                                }
                            />
                            {option}
                        </label>
                    ))}
                </div>
            )}

            {question.questionType === 'Checkbox' && (
                <div>
                    {question.options?.map((option, idx) => (
                        <label key={idx}>
                            <input
                                type="checkbox"
                                name={`question-${question.id}`}
                                value={option}
                                checked={answers[question.id]?.includes(option)}
                                onChange={(e) =>
                                    handleCheckboxChange(question.id, e.target.value)
                                }
                            />
                            {option}
                        </label>
                    ))}
                </div>
            )}

            {question.questionType === 'Textbox' && (
                <div>
                    <input
                        type="text"
                        name={`question-${question.id}`}
                        value={answers[question.id] || ''}
                        onChange={(e) =>
                            handleChange(question.id, e.target.value)
                        }
                    />
                </div>
            )}

            <div>
                <button onClick={handlePrevious} disabled={index === 0}>
                    Previous
                </button>
                <button onClick={handleNext} disabled={index === questions.length - 1}>

                    Next
                </button>
            </div>
            <label>
                Enter your email:
                <input
                    type="email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    placeholder="example@gmail.com"
                    required
                />
            </label>
            <button onClick={handleSubmit}>Submit</button>
        </div>
    );
};

Quiz.propTypes = {
    questions: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            questionText: PropTypes.string.isRequired,
            questionType: PropTypes.string.isRequired,
            options: PropTypes.arrayOf(PropTypes.string),
        })
    ).isRequired,
};

export default Quiz;