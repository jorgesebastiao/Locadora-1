import React from 'react';
import { Link } from 'react-router-dom';
import { FiPower, FiTrash2 } from 'react-icons/fi';

import './styles.css';

export default function Routes() {
    return (
        <div className="profile-container">
            <header>
                <span>Bem vindo Cliente</span>

                <Link className="button" to="/rents/new">Criar nova locação</Link>
                <button type="button">
                    <FiPower size={18} color="#24D3E6"/>
                </button>
            </header>
            <h1>Locações realizadas</h1>
            <ul>
                <li>
                    <strong>Filme:</strong>
                    <p>Homem Aranha</p>
                    <strong>Data da locação:</strong>
                    <p>2020/09/15 00:19</p>
                    <strong>Filmes:</strong>
                    <ul> 
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                    </ul>
                    <button type="button">
                                            <FiTrash2 size={20} color="#a8a8b3"/>
                    </button>
                    
                </li>
                <li>
                    <strong>Filme:</strong>
                    <p>Homem Aranha</p>
                    <strong>Data da locação:</strong>
                    <p>2020/09/15 00:19</p>
                    <strong>Filmes:</strong>
                    <ul>
                    <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                    </ul>
                </li>
                <li>
                    <strong>Filme:</strong>
                    <p>Homem Aranha</p>
                    <strong>Data da locação:</strong>
                    <p>2020/09/15 00:19</p>
                    <strong>Filmes:</strong>
                    <ul>
                    <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                    </ul>
                </li>
                <li>
                    <strong>Filme:</strong>
                    <p>Homem Aranha</p>
                    <strong>Data da locação:</strong>
                    <p>2020/09/15 00:19</p>
                    <strong>Filmes:</strong>
                    <ul>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                        <li>
                            <strong>Nome:</strong>
                            <p>Capitão américa</p>
                            <strong>Genêro:</strong>
                            <p>Ação</p>
                        </li>
                    </ul>
                </li>
            </ul>
        </div>
    );
}