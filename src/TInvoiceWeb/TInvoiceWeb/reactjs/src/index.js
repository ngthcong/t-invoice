import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import "./localization/i18n"
import { Provider } from 'unistore/react'
import store from './store/init';
import { AppModuleProvider } from './modules/AppModule';

ReactDOM.render(
  // <React.StrictMode>
  // This provider is the old context, so we have to disable strict mode to remove warning from React
    <Provider store={store}>
      <AppModuleProvider>
        <App />
      </AppModuleProvider>
    </Provider>
  // </React.StrictMode>,
  ,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
