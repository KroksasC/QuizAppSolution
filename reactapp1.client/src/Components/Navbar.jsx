import { useState} from "react";
import "./Navbar.css";
import { Link, NavLink } from "react-router-dom";

export const Navbar = () => {
    const [menuOpen, setMenuOpen] = useState(false);

    return (
        <nav>
            <Link to="/" className="title">
                <img src="./public/Quiz Logo.jpg" alt="Logo" />
            </Link>
            <div className="menu" onClick={() => setMenuOpen(!menuOpen)}>
                <span></span>
                <span></span>
                <span></span>
            </div>
            <ul className={menuOpen ? "open" : ""}>
                <li>
                    <NavLink to="/" onClick={() => setMenuOpen(false)}>
                        Quiz
                    </NavLink>
                </li>
                <li>
                    <NavLink to="/dashboard" onClick={() => setMenuOpen(false)}>
                        Dashboard
                    </NavLink>
                </li>
            </ul>
        </nav>
    );
};
