import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <header>
      <div id="navigation">
        <ul className="nav-links">
          <li className="nav-item">
            <Link to="/">Launches</Link>
          </li>
          <li className="nav-item">
            <Link to="/rockets">Rockets</Link>
          </li>
        </ul>
      </div>
    </header>
  );
};

export default Header;
