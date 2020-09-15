import React from 'react';
import { Link } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi';

import './styles.css';

export default function Register() {
    return (
        <div className="register-container">
            <div className="content">
                <section>
                    <h1>Cadastro de Cliente</h1>
                    <p>Por favor insira os dados para realizar o cadastro do cliente</p>

                    <Link className="back-link" to="/">
                        <FiArrowLeft size={16} color="#24D3E6"/>
                        Voltar para Logon
                    </Link>
                </section>
                <form>
                    
                    <input type="text" placeholder="Nome do Cliente"/>
                    <input type="text" placeholder="CPF"/>

                    <button className="button" type="submit">Cadastrar</button>
                </form>
            </div>
        </div>

    );
}