import { useEffect, useState } from 'react';
import QuizDashboard from './QuizDashboard';


function QuizDashboardPage() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        async function populateUserData() {
            try {
                const response = await fetch('users');
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                const data = await response.json();
                setUsers(data);
            } catch (error) {
                console.error('Error fetching users:', error);
            }
        }
        populateUserData();
    }, []);

    return (
        <div>
            {users.length > 0 ? (
                <QuizDashboard users={users} />
            ) : (
                <h1>No user data provided..</h1>
            )}
        </div>
    );
}

export default QuizDashboardPage;
