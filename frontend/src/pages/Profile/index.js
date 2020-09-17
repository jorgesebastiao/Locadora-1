import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiPower, FiTrash2 } from 'react-icons/fi';

import './styles.css';
import api from '../../services/api';

export default function Profile() {

    const [rents, setRents] = useState([]);

    const history = useHistory();

    const customerName = localStorage.getItem('customerName');
    const customerId = localStorage.getItem('customerId');

    useEffect(() => {
        api.get('rent', {
            headers: {
                Authorization: customerId,
            }
        }).then(response => {
            setRents(response.data);
        })
    }, [customerId]);

    async function handleDeleteIncident(id) {
        try {
            await api.delete(`rent/${id}`);

            setRents(rents.filter(rent => rent.id !== id));

        } catch (err) {
            alert("Erro ao deletar caso. Tente novamente!");
        }
    }

    function handleLogout() {
        localStorage.clear();

        history.push('/');
    }

    return (
        <div className="profile-container">
            <header>
                <span>Bem vindo {customerName}</span>

                <Link className="button" to="/rents/new">Criar nova locação</Link>
                <button type="button" onClick={handleLogout}>
                    <FiPower size={18} color="#24D3E6"/>
                </button>
            </header>
            <h1>Locações realizadas</h1>
            <ul>
                {/*
                    Mapear de forma reversa para as locações mais recentes ficarem no topo
                */rents.slice(0).reverse().map(rent => (
                    <li key={rent.id}>
                    <strong>Data da locação:</strong>
                    <p>{ new Date(rent.rentDate + 'Z').toLocaleString() }</p>
                    <strong>Filmes:</strong>
                    <ul> 
                        {rent.rentMovies.map(m => (
                            <li key={m.movieId}>
                                <strong>Nome:</strong>
                                <p>{m.movie.name}</p>
                                <strong>Genêro:</strong>
                                <p>{m.movie.genre.name}</p>
                            </li>
                        ))}
                    </ul>
                    
                    <button onClick={() => handleDeleteIncident(rent.id)} type="button">
                        <FiTrash2 size={20} color="#a8a8b3"/>
                    </button>
                    
                </li>
                ))}
            </ul>
        </div>
    );
}