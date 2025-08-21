import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
// አስፈላጊ ከሆነ ከ API service ወደ ትክክለኛው መንገድ አምራር
import styles from './LoginPage.module.css';

const LoginPage = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleSubmit = async (e) => {
        e.preventDefault();
        // እዚህ ከ backendህ ጋር የሚገናኝ የ API ጥሪ ይገባል
        // ለምሳሌ: login(username, password);
        
        // ለጊዜው ስኬታማ ከሆነ ወደ ዳሽቦርድ ይሂድ
        if (username === 'admin' && password === 'admin') {
            alert('Login Successful!');
            navigate('/dashboard'); // የፈለግኸውን ገጽ እዚህ አስገባ
        } else {
            alert('Invalid credentials. Please try again.');
        }
    };

    return (
        <div className={styles.loginContainer}>
            <form onSubmit={handleSubmit} className={styles.loginForm}>
                <h2 className={styles.title}>Login to Your Account</h2>
                <div className={styles.formGroup}>
                    <label className={styles.label}>Username:</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                        required
                        className={styles.input}
                    />
                </div>
                <div className={styles.formGroup}>
                    <label className={styles.label}>Password:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                        className={styles.input}
                    />
                </div>
                <button type="submit" className={styles.loginButton}>Login</button>
            </form>
        </div>
    );
};

export default LoginPage;