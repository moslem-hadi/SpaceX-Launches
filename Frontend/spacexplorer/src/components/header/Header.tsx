import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <header>
      <div id="navigation">
        <ul className="nav-links">
          <li className="nav-item">
            <Link to="/">Timeline</Link>
          </li>
          <li className="nav-item">
            <a href="/vehicles/falcon-heavy/">Launch List</a>
          </li>
          <li className="nav-item">
            <a href="/vehicles/dragon/">Rockets</a>
          </li>
          <li className="nav-item">
            <a href="/vehicles/starship/">Crew Members</a>
          </li>
        </ul>
      </div>
    </header>
  );
};

export default Header;
