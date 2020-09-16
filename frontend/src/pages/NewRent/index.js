import React, { useState, useEffect } from 'react';
import { Link, useHistory } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Checkbox from '@material-ui/core/Checkbox';

import './styles.css';
import api from '../../services/api';

export default function NewRent() {

  const [checked, setChecked] = useState([0]);
  const [movies, setMovies] = useState([]);

  const customerId = localStorage.getItem('customerId');

  const history = useHistory();

  useEffect(() => {
    api.get('movie').then(response => {
      setMovies(response.data);
    })
  }, []);

  const handleToggle = (value) => () => {
    const currentIndex = checked.indexOf(value);
    const newChecked = [...checked];

    if (currentIndex === -1) {
      newChecked.push(value);
    } else {
      newChecked.splice(currentIndex, 1);
    }

    setChecked(newChecked);
  };

  async function handleSave(e) {
    e.preventDefault();

    const moviesChecked = movies.filter(m => checked.indexOf(m) !== -1);

    const rentMovies = moviesChecked.map(m => ({ movieId: m.id }));

    if (rentMovies.length === 0)
    {
      alert("É necessário selecionar no minímo 1 filme");

      return;
    }

    const rentDate = new Date().toJSON();

    const data = {
      customerId,
      rentMovies,
      rentDate
    };

    try
    {
        await api.post('rent', data);

        alert(`Salvo com sucesso!`);

        history.push('/profile');
    } catch(err) {
            alert('Erro ao tentar salvar. Tente novamente.');
    }
}

  return (
    <div className="new-rent-container">
      <div className="content">
        <section>
          <h1>Criar Locação</h1>
          <p>Por favor selecione os filmes que deseja realizar a locação</p>

          <Link className="back-link" to="/profile">
            <FiArrowLeft size={16} color="#24D3E6" />
                        Voltar para meu perfil
                    </Link>
        </section>

        <div className="list-items">
          <List>{movies.map((movie) => {
            return (
              <ListItem key={movie.id} role={undefined} dense button onClick={handleToggle(movie)}>
                <ListItemIcon>
                  <Checkbox
                    edge="start"
                    checked={checked.indexOf(movie) !== -1}
                    tabIndex={-1}
                    disableRipple
                  />
                </ListItemIcon>
                <ListItemText id={movie.id} primary={`Filme: ${movie.name}`} />
              </ListItem>
            );
          })}
          </List>

          <button className="button" type="button" onClick={handleSave}>Salvar</button>

        </div>
      </div>
    </div>
  );
}