import React from 'react';
import styles from './AboutPage.module.css';

const AboutPage = () => {
    return (
        <div className={styles.aboutContainer}>
            <section className={styles.aboutSection}>
                <h1 className={styles.title}>About Our Smart Inventory System</h1>
                <p className={styles.description}>
                    Our project is a comprehensive and modern solution designed to streamline inventory operations for businesses of all sizes. Built on a robust full-stack foundation using **ASP.NET Core** and **React**, it provides a secure and efficient platform to manage items, track invoices, and monitor real-time stock levels.
                </p>
                <p className={styles.description}>
                    We believe in the power of technology to simplify complex tasks. By leveraging cutting-edge frameworks, we've created a scalable, maintainable, and user-friendly application that helps businesses make smarter decisions with data-driven insights.
                </p>
            </section>
            
            <section className={styles.teamSection}>
                <h2 className={styles.sectionTitle}>Meet the Team</h2>
                <div className={styles.teamMember}>
                    <img src="https://via.placeholder.com/150" alt="Team Member Profile" className={styles.profileImage} />
                    <h3 className={styles.memberName}>BINIYAM TEHAKALE</h3>
                    <p className={styles.memberRole}>Full-Stack Developer & Project Lead</p>
                    <p className={styles.memberBio}>
                        Responsible for the overall architecture and development of both the frontend and backend.
                    </p>
                </div>
            </section>
        </div>
    );
};

export default AboutPage;