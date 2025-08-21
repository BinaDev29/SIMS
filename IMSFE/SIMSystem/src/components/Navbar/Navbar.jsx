import React, { useContext } from 'react';
import { Link } from 'react-router-dom';
import { ThemeContext } from '../../Theme'; // Contextን ማስገባት
import styles from './Navbar.module.css';

const Navbar = () => {
    const { theme, toggleTheme } = useContext(ThemeContext);

    return (
        <nav className={styles.navbar}>
            <div className={styles.logo}>
                <Link to="/" className={styles.link}>
                    Smart Inventory
                </Link>
            </div>
            <ul className={styles.navLinks}>
                <li><Link to="/" className={styles.link}>Home</Link></li>
                <li><Link to="/about" className={styles.link}>About</Link></li>
                <li><Link to="/contact" className={styles.link}>Contact</Link></li>
                <li><Link to="/login" className={styles.link}>Login</Link></li>
                <li>
                    <button onClick={toggleTheme} className={styles.themeToggle}>
                        {theme === 'light' ? '🌙' : '☀️'}
                    </button>
                </li>
            </ul>
        </nav>
    );
};

export default Navbar;