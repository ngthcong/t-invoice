import React from 'react';
import logo from './logo.svg';
import './styles/App.css';
import { Trans } from 'react-i18next';
import AppRouter from './routes/AppRouter';
import { Link, BrowserRouter } from 'react-router-dom';

const App = () => {
  return (<BrowserRouter>
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          <Trans>
            Welcome To <b>React</b>
          </Trans>
        </p>
        <div style={{ paddingBottom: 8}}>
          <AppRouter />
        </div>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          <Trans>
            Learn React
          </Trans>
        </a>
        <div>
          <Link to="/" style={{ marginRight: 16 }}>
            Button Counter
          </Link>
          <Link to="/timer">
            Time Counter
          </Link>
        </div>
      </header>
    </div>
    </BrowserRouter>);
}

export default App;
