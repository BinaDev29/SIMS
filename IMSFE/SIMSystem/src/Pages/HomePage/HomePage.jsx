import React from 'react';
import styles from './HomePage.module.css';

const HomePage = () => {
    return (
        <div className={styles.container}>
            <header className={styles.heroSection}>
                <h1 className={styles.heroTitle}>Smart Inventory Management System</h1>
                <p className={styles.heroSubtitle}>
                    Your ultimate solution for seamless inventory control and business automation.
                </p>
            </header>

            <section className={styles.contentSection}>
                <div className={styles.featureGrid}>
                    <div className={styles.featureCard}>
                        <h3 className={styles.featureTitle}>Real-time Stock Tracking</h3>
                        <p>
                            Instantly monitor your inventory levels across all locations. Get real-time updates and notifications to prevent stockouts.
                        </p>
                    </div>
                    <div className={styles.featureCard}>
                        <h3 className={styles.featureTitle}>Automated Invoicing</h3>
                        <p>
                            Generate professional invoices with a single click. Our system automates the billing process from start to finish.
                        </p>
                    </div>
                    <div className={styles.featureCard}>
                        <h3 className={styles.featureTitle}>Secure & Scalable</h3>
                        <p>
                            Built on a robust and secure architecture, our system grows with your business while keeping your data safe.
                        </p>
                    </div>
                    <div className={styles.featureCard}>
                        <h3 className={styles.featureTitle}>Comprehensive Reporting</h3>
                        <p>
                            Access detailed reports and analytics on sales, stock movement, and performance to make data-driven decisions.
                        </p>
                    </div>
                </div>
            </section>
        </div>
    );
};

export default HomePage;