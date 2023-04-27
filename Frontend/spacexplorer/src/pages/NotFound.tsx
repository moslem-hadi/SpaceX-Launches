import { Link } from 'react-router-dom';

const NotFound = () => {
  return (
    <>
      <div className="central-body">
        <img className="image-404" src="/assets/images/404.svg" width="300px" />
        <Link to="/" className="btn-go-home">
          GO BACK HOME
        </Link>
      </div>
    </>
  );
};

export default NotFound;
