import './App.css';
import Header from './components/header/Header';
import Home from './pages/Home';
import { Routes, Route } from 'react-router-dom';

import { ToastContainer } from 'react-toastify';
import ViewPage from './pages/View';
import NotFound from './pages/NotFound';
function App() {
  return (
    <>
      <Header />

      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/view/:flightNumber" element={<ViewPage />} />
        <Route path="*" element={<NotFound />} />
      </Routes>
      <ToastContainer />
    </>
  );
}

export default App;
