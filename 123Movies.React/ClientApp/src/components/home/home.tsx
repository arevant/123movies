import * as React from 'react';
import ViewMovies from '../movies/viewmovies';
import './home.css';

const Home: React.FC = (props: any) => {

  return (
    <div>
      <div className={`d-flex justify-content-between`}>
        <h3>Hey there, here are the movies available on this platform. We have some exciting movies coming to this platform. Have a look at those as well. Happy browsing!</h3>
      </div>
      <ViewMovies />
    </div>
  );
}

export default Home;
