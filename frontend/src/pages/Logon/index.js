import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiLogIn } from 'react-icons/fi';

import api from '../../services/api';
import './styles.css';

export default function Logon() {
    const [id, setId] = useState('');
    const history = useHistory();

    async function handleLogin(e) {
        e.preventDefault();

        try {

            if (id === '') {
                alert('Login inválido!');

                return;
            }

            const response = await api.get(`customer/${ id }`, );

            localStorage.setItem('customerId', id);
            localStorage.setItem('customerName', response.data.name);

            history.push('/profile');
        } catch (err) {
            alert('Falha no login. Tente Novamente!');
        }
    }

    return (
        <div className="logon-container">
            <section className="form">
                <form onSubmit={handleLogin}>
                    <h1>Faça seu Logon</h1>
                    <input
                        placeholder="Identificador do Cliente"
                        value={id}
                        onChange={e => setId(e.target.value) }/>
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