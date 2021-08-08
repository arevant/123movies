import React from 'react';
import { Link } from 'react-router-dom';
import Gallery from '../../uicomponents/gallery/gallery';
import './moviedetail.css';

const MovieDetail = (props) => {
    const [detail, setDetail] = React.useState(null);
    React.useEffect(() => {
        setDetail(props.location.state);
    }, []);

    return (
        <>
            {detail?.title ? <div className="d-flex flex-column card m-2">
                <Link to="/" className="m-2" >Back</Link>
                <div className="d-flex justify-content-around mt-2">
                    <img src={detail?.poster} alt="Not found" className="poster" />
                    <Gallery images={detail?.stills} />
                </div>
                <div className="m-3">
                    <div className=""><b>Title:</b> {detail?.title}</div>
                    <div className="mt-2"><b>Detail:</b> {detail?.plot}</div>
                    <div className="mt-2"><b>Rating:</b> {detail?.imdbRating} </div>
                    <div className="mt-2"><b>Language:</b> {detail?.language}</div>
                    <div className="mt-2"><b>Location:</b> {detail?.location}</div>
                    <div className="mt-2"><b>Sound effects:</b> {(detail?.soundEffects || []).map((item, index) => { return <span className="mr-1" key={`${item}_${index}`}> {item} </span> })}</div>
                </div>
            </div> : <div>
                Invalid data entered in URL. Kindly navigate through the application. <Link to="/" className="m-2" >Back</Link>
            </div>}
        </>
    )
}

export default MovieDetail;
