import React, { useState } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi';

import api from '../../services/api';
import './styles.css';

export default function Register() {

    const [name, setName] = useState('');
    const [cpf, setCpf] = useState('');

    const history = useHistory();

    async function handleRegister(e) {
        e.preventDefault();

        const data = {
            name,
            cpf
        };

        try
        {
            const response = await api.post('customer', data);

            alert(`Seu ID de acesso é: ${response.data}`);

            history.push('/');
        } catch(err) {
            if (err !== undefined & err.response !== undefined)
            {
                alert(`Erro no cadastro. Tente novamente. \n ${err.response.data}`);
            }
            else
            {
                alert('Erro no cadastro. Tente novamente.');
            }
        }

    }

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
                <form onSubmit={handleRegister}>
                    
                    <input
                        placeholder="Nome do Cliente"
                        value={name}
                        onChange={e => setName(e.target.value)}
                    />
                    <input
                        placeholder="CPF"
                        value={cpf}
                        onChange={e => setCpf(e.target.value)}/>

                    <button className="button" type="submit">Cadastrar</button>
                </form>
            </div>
        </div>

    );
}