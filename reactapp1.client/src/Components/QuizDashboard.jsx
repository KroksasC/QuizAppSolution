import PropTypes from 'prop-types';
import './QuizDashboard.css';

const QuizDashboard = ({ users }) => {
    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <th></th>
                        <th>Dashboard</th>
                        <th></th>
                    </tr>
                    <tr>
                        <th>Place</th>
                        <th>Email</th>
                        <th>Score</th>
                    </tr>
                </thead>
                <tbody>
                    {users.map((user, index) => {
                        let rowClass = "";
                        if (index === 0) rowClass = "first-place";
                        else if (index === 1) rowClass = "second-place";
                        else if (index === 2) rowClass = "third-place";

                        return (
                            <tr key={user.id} className={rowClass}>
                                <td>{index + 1}#</td>
                                <td>{user.email}</td>
                                <td>{user.finalScore}</td>
                            </tr>
                        );
                    })}
                </tbody>
            </table>
        </div>
    );
};
QuizDashboard.propTypes = {
    users: PropTypes.arrayOf(
        PropTypes.shape({
            id: PropTypes.number.isRequired,
            email: PropTypes.string.isRequired,
            finalScore: PropTypes.number,
        })
    ).isRequired,
};

export default QuizDashboard;