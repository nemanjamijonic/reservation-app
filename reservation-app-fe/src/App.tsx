import React from 'react';
import './App.css';
import "../node_modules/react-toastify/dist/ReactToastify.css";
import { ToastContainer } from 'react-toastify';
import Login from './components/Login/Login';

function App() {
  return (
    <>
      <Login></Login>
      <ToastContainer />
    </>
  );
}

export default App;
