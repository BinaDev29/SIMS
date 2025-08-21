import React from 'react';
import styles from './ContactPage.module.css';

const ContactPage = () => {
    return (
        <div className={styles.contactContainer}>
            <section className={styles.contactInfoSection}>
                <h1 className={styles.title}>Get in Touch with Us</h1>
                <p className={styles.description}>
                    We're here to help! For any questions, support, or feedback, please feel free to reach out to us using the information below.
                </p>
                
                <div className={styles.infoGrid}>
                    <div className={styles.infoCard}>
                        <h3>Email Us</h3>
                        <p>support@inventory.com</p>
                    </div>
                    <div className={styles.infoCard}>
                        <h3>Call Us</h3>
                        <p>+251 9XX XXX XXX</p>
                    </div>
                    <div className={styles.infoCard}>
                        <h3>Our Location</h3>
                        <p>123 Business Avenue, Addis Ababa, Ethiopia</p>
                    </div>
                </div>
            </section>
            
            <section className={styles.formSection}>
                <h2 className={styles.formTitle}>Send a Message</h2>
                <form className={styles.contactForm}>
                    <div className={styles.formGroup}>
                        <label htmlFor="name" className={styles.label}>Your Name</label>
                        <input type="text" id="name" name="name" required className={styles.input} />
                    </div>
                    <div className={styles.formGroup}>
                        <label htmlFor="email" className={styles.label}>Your Email</label>
                        <input type="email" id="email" name="email" required className={styles.input} />
                    </div>
                    <div className={styles.formGroup}>
                        <label htmlFor="message" className={styles.label}>Your Message</label>
                        <textarea id="message" name="message" required rows="5" className={styles.textarea}></textarea>
                    </div>
                    <button type="submit" className={styles.submitButton}>Send Message</button>
                </form>
            </section>
        </div>
    );
};

export default ContactPage;