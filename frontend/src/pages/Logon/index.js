import React from 'react';
import { Link } from 'react-router-dom';
import { FiLogIn } from 'react-icons/fi';

import './styles.css';

export default function Logon() {
    return (
        <div className="logon-container">
            <section className="form">
                <form action="">
                    <h1>Faça seu Logon</h1>
                    <input placeholder="Identificador do Cliente"></input>
                    <button className="button" type="submit">Entrar</button>

                    <Link className="back-link" to="/register">
                        <FiLogIn size={16} color="#24D3E6"/>
                        Não tenho Cadastro
                    </Link>
                </form>
            </section>
        </div>
    );
}