import './App.css';
import "../node_modules/react-toastify/dist/ReactToastify.css";
import { ToastContainer } from 'react-toastify';
import Login from './components/Login/Login';
import Register from './components/Register/Register';

function App() {
  return (
    <>
      <Login></Login>
      <Register />
      <ToastContainer />
    </>
  );
}

export default App;
