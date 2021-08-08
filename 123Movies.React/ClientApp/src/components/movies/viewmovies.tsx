import * as React from 'react';
import { getAll } from "../../apis/moviesApi";
import Dropdown from '../../uicomponents/dropdown/dropdown';
import TextField from '../../uicomponents/textfield/textfield';
import Movie from '../movie/movie';

const ViewMovies: React.FC = () => {
    const [moviesData, setMoviesData] = React.useState([]);
    const [upComing, setUpcoming] = React.useState([]);
    const [nowShowing, setNowShowing] = React.useState([]);
    const [sortValue, setSortValue] = React.useState(0);
    const [locationFilter, setLocationFilter] = React.useState("dummy");

    const sortDropDownValues = [
        { label: "Sort by", value: 0 },
        { label: "Sort by: Ascending", value: 1 },
        { label: "Sort by: Descending", value: 2 }];

    const locationOptions = [
        { label: "Filter by Location", value: "dummy" },
        { label: "Pune", value: "Pune" },
        { label: "Delhi", value: "Delhi" },
        { label: "Bangalore", value: "Bangalore" },
        { label: "Chennai", value: "Chennai" }];

    React.useEffect(() => {
        getMoviesData();
    }, []);

    const sortData = (value, data = [...moviesData]) => {
        if (value === 2) {
            data.sort((a, b) => (a.title > b.title ? -1 : 1));
        } else if (value === 1) {
            data.sort((a, b) => (a.title < b.title ? -1 : 1));
        }

        setSortValue(value);
        splitData(data);
    }

    const getMoviesData = async () => {
        const movieDataResponse = await getAll();
        if (movieDataResponse.data !== null) {
            const movieData = movieDataResponse.data.result;
            movieData.forEach(element => {
                element.listingType = element.listingStatus === 1 ? "Upcoming" : "Now showing";
            });

            setMoviesData(movieData);
            splitData(movieData);
        }
    }

    const filterData = (val) => {
        let data = [...moviesData];

        data = data.filter(x => {
            if (x.title.toLowerCase().indexOf(val.toLowerCase()) !== -1) {
                return true;
            }
            return false;
        });
        sortData(sortValue, data);
    }

    const filterByLocation = (val) => {
        let data = [...moviesData];
        if (val !== "dummy") {
            data = data.filter(x => {
                if (x.location.toLowerCase().indexOf(val.toLowerCase()) !== -1) {
                    return true;
                }
                return false;
            });
            sortData(sortValue, data);
        } else {
            sortData(sortValue);
        }
        setLocationFilter(val);
    }

    const filterByLanguage = (val) => {
        let data = [...moviesData];

        data = data.filter(x => {
            if (x.language.toLowerCase().indexOf(val.toLowerCase()) !== -1) {
                return true;
            }
            return false;
        });
        sortData(sortValue, data);
    }

    const splitData = (movieData) => {
        const upComingMovies = movieData.filter(x => x.listingType === "Upcoming");
        const nowShowingMovies = movieData.filter(x => x.listingType === "Now showing");
        setUpcoming(upComingMovies);
        setNowShowing(nowShowingMovies);
    }

    return (
        <div className="mt-4">
            <div className="d-flex justify-content-end">
                <div className="margin-right"><TextField input={{ onChange: (val) => filterByLanguage(val) }} label={'Movies by Language'} /></div>
                <div className="margin-right"><Dropdown options={locationOptions} meta={{}} input={{ onChange: (e) => filterByLocation(e), value: locationFilter }} /></div>
                <div className="margin-right"><TextField input={{ onChange: (val) => filterData(val) }} label={'Movies by Title'} /></div>
                <div><Dropdown options={sortDropDownValues} meta={{}} input={{ onChange: (e) => sortData(e), value: sortValue }} /></div>
            </div>
            <Movie items={nowShowing} header={"Now showing"} />
            <hr className="mtb-2" />
            <Movie items={upComing} header={"Upcoming"} />
        </div>);
}

export default ViewMovies;
