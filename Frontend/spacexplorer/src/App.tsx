import './App.css';
import Header from './components/header/Header';
import Home from './pages/Home';

import { ToastContainer } from 'react-toastify';
function App() {
  return (
    <>
      <Header />
      <Home />
      <ToastContainer />
    </>
  );
}

export default App;
