import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { FiArrowLeft } from 'react-icons/fi'
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';
import Checkbox from '@material-ui/core/Checkbox';

import './styles.css';

export default function NewRent() {

  const [checked, setChecked] = useState([0]);

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

    return (
        <div className="new-rent-container">
            <div className="content">
                <section>
                    <h1>Criar Locação</h1>
                    <p>Por favor selecione os filmes que deseja realizar a locação</p>

                    <Link className="back-link" to="/profile">
                        <FiArrowLeft size={16} color="#24D3E6"/>
                        Voltar para meu perfil
                    </Link>
                </section>

            <div className="list-items">

            
                <List>
                    {[0, 1, 2, 3].map((value) => {
                              const labelId = `checkbox-list-label-${value}`;
                              
                              return (
                                          <ListItem key={value} role={undefined} dense button onClick={handleToggle(value)}>
            <ListItemIcon>
              <Checkbox
                edge="start"
                checked={checked.indexOf(value) !== -1}
                tabIndex={-1}
                disableRipple
                inputProps={{ 'aria-labelledby': labelId }}
              />
            </ListItemIcon>
            <ListItemText id={labelId} primary={`Line item ${value + 1}`} />
          </ListItem>
        );
      })}
    </List>

    <button className="button" type="button">Salvar</button>

    </div>
            </div>
            
        </div>

    );
}