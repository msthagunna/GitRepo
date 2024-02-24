import { useState } from 'react';
import '../css/Search.css';
import SearchResult from './SearchResult';
import PropTypes from 'prop-types';

const Search = ({onSearch }) => {
  const [query, setQuery] = useState('');
  const [results, setResults] = useState([]);

  const handleSearch = () => {
    const dummyData = [
      { id: 1, name: 'Result 1', snippet: 'Description 1' },
      { id: 2, name: 'Result 2', snippet: 'Description 2' },
      { id: 3, name: 'Result 3', snippet: 'Description 3' },
      { id: 4, name: 'Result 4', snippet: 'Description 4' },
      { id: 5, name: 'Result 5', snippet: 'Description 5' },
    ];

    const filteredResults = dummyData.filter((result) =>
      result.name.toLowerCase().includes(query.toLowerCase())
    );
    if(query==""){
      setResults([]);
    }
    else
    {
    setResults(filteredResults);
    onSearch(filteredResults);
    }
  };
  const handleKeyPress = (event) => {
    if (event.key === 'Enter') {
      handleSearch();
    }
  };
  const handleClearClick = () => {
    setQuery('');
    setResults([]);
  }

  return (
    <div className="search-container">
      <input
        type="text"
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        onKeyDown ={handleKeyPress}
        placeholder="Enter here your search query"
      />
      {query && (
        <i className="fas fa-times-circle clear-icon" onClick={handleClearClick}></i>
      )}
      <button onClick={handleSearch}>Search</button>

      <ul className="search-results">
        {results.map((result) => (
          <SearchResult key={result.id} result={result} />
        ))}
      </ul>
    </div>
  );
};
Search.propTypes = {
  onSearch: PropTypes.func.isRequired
};
export default Search;